using Neuron.Core.Events;
using Neuron.Core.Meta;
using Ninject;
using Synapse3.SynapseModule.Events;

namespace SerpentsHand;

[Automatic]
public class EventHandlers : Listener
{
    [Inject]
    public SerpentsHand Plugin { get; set; }

    [EventHandler]
    public void Select(SelectTeamEvent ev)
    {
        if (ev.TeamId == 1 && UnityEngine.Random.Range(1f, 100f) <= Plugin.Config.SpawnChance) ev.TeamId = 7;
    }
}
