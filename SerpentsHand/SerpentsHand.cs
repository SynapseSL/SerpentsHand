using Neuron.Core.Meta;
using Neuron.Core.Plugins;
using Synapse3.SynapseModule;

namespace SerpentsHand;

[Automatic]
[Plugin(
    Name = "SerpentsHand",
    Author = "Dimenzio",
    Description = "Adds the new Spawnable Team SerpentsHand to the Game",
    Version = "3.0.0"
)]
public class SerpentsHand : ReloadablePlugin<Config, Translation>
{
    public override void EnablePlugin()
    {
        Logger.Info("SerpentsHand Enabled!");
    }
}