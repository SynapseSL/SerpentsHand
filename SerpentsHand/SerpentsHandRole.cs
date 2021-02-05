using Synapse.Api.Roles;
using System.Collections.Generic;

namespace SerpentsHand
{
    public class SerpentsHandRole : Synapse.Api.Roles.Role
    {
        public override int GetRoleID() => 30;

        public override string GetRoleName() => "SerpentsHand";

        public override int GetTeamID() => 7;

        public override List<int> GetFriendsID() => PluginClass.Config.friendlyfire ? new List<int>() : new List<int> { (int)Team.SCP };

        public override List<int> GetEnemiesID() => new List<int> { (int)Team.CDP, (int)Team.MTF, (int)Team.RSC };

        public override void Spawn()
        {
            Player.RoleType = PluginClass.Config.SpawnRole;
            Player.MaxHealth = PluginClass.Config.Health;
            Player.Health = PluginClass.Config.Health;
            Player.Ammo5 = PluginClass.Config.Ammo.Ammo5;
            Player.Ammo7 = PluginClass.Config.Ammo.Ammo7;
            Player.Ammo9 = PluginClass.Config.Ammo.Ammo9;

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
