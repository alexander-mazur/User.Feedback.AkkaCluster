using System.Configuration;
using System.Linq;

using Akka.Actor;
using Akka.Configuration;
using Akka.Configuration.Hocon;

using ConfigurationException = Akka.Configuration.ConfigurationException;

namespace User.Feedback.Discovery
{
    /// <summary>
    /// Launcher for the Discovery Service <see cref="ActorSystem"/>
    /// THIS IS COPY/PASTE of Lighthouse Service Discovery
    /// </summary>
    public static class DiscoveryHostFactory
    {
        public static ActorSystem LaunchLighthouse(string ipAddress = null, int? specifiedPort = null)
        {
            var systemName = "discovery";
            var section = (AkkaConfigurationSection)ConfigurationManager.GetSection("akka");
            var clusterConfig = section.AkkaConfig;

            var lighthouseConfig = clusterConfig.GetConfig("discovery");
            if (lighthouseConfig != null)
            {
                systemName = lighthouseConfig.GetString("actorsystem", systemName);
            }

            var remoteConfig = clusterConfig.GetConfig("akka.remote");
            ipAddress = ipAddress ??
                        remoteConfig.GetString("helios.tcp.public-hostname") ??
                        "127.0.0.1"; //localhost as a final default
            int port = specifiedPort ?? remoteConfig.GetInt("helios.tcp.port");

            if (port == 0)
            {
                throw new ConfigurationException("Need to specify an explicit port for Lighthouse. Found an undefined port or a port value of 0 in App.config.");
            }

            var selfAddress = $"akka.tcp://{systemName}@{ipAddress}:{port}";
            var seeds = clusterConfig.GetStringList("akka.cluster.seed-nodes");
            if (!seeds.Contains(selfAddress))
            {
                seeds.Add(selfAddress);
            }

            var injectedClusterConfigString = seeds.Aggregate("akka.cluster.seed-nodes = [", (current, seed) => current + (@"""" + seed + @""", "));
            injectedClusterConfigString += "]";

            var finalConfig = ConfigurationFactory.ParseString(
                $@"akka.remote.helios.tcp.public-hostname = {ipAddress} 
akka.remote.helios.tcp.port = {port}")
                .WithFallback(ConfigurationFactory.ParseString(injectedClusterConfigString))
                .WithFallback(clusterConfig);

            return ActorSystem.Create(systemName, finalConfig);
        }
    }
}
