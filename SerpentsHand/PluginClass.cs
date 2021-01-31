using Synapse.Api.Plugin;
using Synapse;

namespace SerpentsHand
{
    [PluginInformation(
        Author = "Dimenzio",
        Description = "Adds the SerpentsHand to the game",
        LoadPriority = 0,
        Name = "SerpentsHand",
        SynapseMajor = 2,
        SynapseMinor = 4,
        SynapsePatch = 2,
        Version = "v.1.1.0"
        )]
    public class PluginClass : AbstractPlugin
    {
        [Config(section = "SerpentsHand")]
        public static PluginConfig Config;

        public override void Load()
        {
            Server.Get.RoleManager.RegisterCustomRole<SerpentsHandRole>();
            new EventHandlers();
            base.Load();
        }
    }
}
