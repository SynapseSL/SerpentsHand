using Synapse;

namespace SerpentsHand
{
    public class EventHandlers
    {
        public EventHandlers()
        {
            Server.Get.Events.Player.PlayerSetClassEvent += SetClass;
            Server.Get.Events.Round.TeamRespawnEvent += Respawn;
        }

        private void Respawn(Synapse.Api.Events.SynapseEventArguments.TeamRespawnEventArgs ev)
        {
            if(ev.Team == Respawning.SpawnableTeamType.ChaosInsurgency && UnityEngine.Random.Range(1f,100f) <= PluginClass.Config.SpawnChance) ev.TeamID = 7;
        }

        private void SetClass(Synapse.Api.Events.SynapseEventArguments.PlayerSetClassEventArgs ev)
        {
            if (ev.Player.RoleID == 30)
                ev.Position = PluginClass.Config.SpawnPoint.Parse().Position;
        }
    }
}
