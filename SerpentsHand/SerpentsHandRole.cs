using Synapse.Api.Roles;
using System.Collections.Generic;

namespace SerpentsHand
{
    public class SerpentsHandRole : Synapse.Api.Roles.Role
    {
        public override int GetRoleID() => 30;

        public override string GetRoleName() => "SerpentsHand";

        public override Team GetTeam() => Team.SCP;

        public override List<Team> GetFriends() => PluginClass.Config.friendlyfire ? new List<Team> { } : new List<Team> { Team.SCP };

        public override void Spawn()
        {
            Player.RoleType = PluginClass.Config.SpawnRole;
            Player.MaxHealth = PluginClass.Config.Health;
            Player.Health = PluginClass.Config.Health;

            Player.DisplayInfo = PluginClass.Config.CustomRoleName;
            Player.RemoveDisplayInfo(PlayerInfoArea.Role);
            Player.OpenReportWindow(PluginClass.Config.SpawnMessage.Replace("\\n", "\n"));
        }

        public override void DeSpawn()
        {
            Player.DisplayInfo = string.Empty;
            Player.AddDisplayInfo(PlayerInfoArea.Role);
        }
    }
}
