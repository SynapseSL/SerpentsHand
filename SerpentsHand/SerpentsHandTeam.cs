using Synapse;
using Synapse.Api;
using Synapse.Api.Teams;
using System.Collections.Generic;

namespace SerpentsHand
{
    [SynapseTeamInformation(
        ID = 7,
        Name = "SerpentsHand"
        )]
    public class SerpentsHandTeam : SynapseTeam
    {
        public override void Spawn(List<Player> players)
        {
            if (players.Count > PluginClass.Config.SpawnSize)
                players = players.GetRange(0, PluginClass.Config.SpawnSize);

            foreach (var ply in players)
                ply.RoleID = 30;

            Server.Get.Map.GlitchedCassie(PluginClass.Config.Cassie);
        }
    }
}
