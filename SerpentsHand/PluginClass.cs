using Synapse;
using Synapse.Api.Plugin;
using Synapse.Translation;

namespace SerpentsHand
{
    [PluginInformation(
        Author = "Dimenzio",
        Description = "Adds the SerpentsHand to the game",
        LoadPriority = 1,
        Name = "SerpentsHand",
        SynapseMajor = 2,
        SynapseMinor = 7,
        SynapsePatch = 1,
        Version = "v.1.2.2"
        )]
    public class PluginClass : AbstractPlugin
    {
        [Config(section = "SerpentsHand")]
        public static PluginConfig Config { get; set; }

        [SynapseTranslation]
        public static new SynapseTranslation<PluginTranslation> Translation { get; set; }

        public override void Load()
        {
            Server.Get.TeamManager.RegisterTeam<SerpentsHandTeam>();
            Server.Get.RoleManager.RegisterCustomRole<SerpentsHandRole>();
            Translation.AddTranslation(new PluginTranslation());
            Translation.AddTranslation(new PluginTranslation()
            {
                SpawnMessage = "<i>Du bist ein <color=green>SerpentsHand</color></i>\\n<i>Dein Ziel ist es den SCPs zu helfen!</i>\\n<b>Drück Esc zum schließen</b>",
            }, "GERMAN");
            new EventHandlers();
            base.Load();
        }
    }
}
