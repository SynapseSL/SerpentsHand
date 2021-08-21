using System.Collections.Generic;

namespace SerpentsHand
{
    public class SerpentsHandRole : Synapse.Api.Roles.Role
    {
        public override int GetRoleID() => 30;

        public override string GetRoleName() => "SerpentsHand";

        public override int GetTeamID() => 7;

        public override List<int> GetFriendsID() => PluginClass.Config.Friendlyfire ? new List<int> { (int)Team.SCP } : new List<int> { (int)Team.SCP, 7 };

        public override List<int> GetEnemiesID() => new List<int> { (int)Team.CDP, (int)Team.MTF, (int)Team.RSC };

        public override void Spawn()
        {
            Player.RoleType = PluginClass.Config.SpawnRole;
            Player.MaxHealth = PluginClass.Config.Health;
            Player.Health = PluginClass.Config.Health;
            Player.Inventory.Clear();
            PluginClass.Config.Inventory.Apply(Player);

            Player.DisplayInfo = PluginClass.Config.CustomRoleName;
            Player.RemoveDisplayInfo(PlayerInfoArea.Role);
            Player.OpenReportWindow(PluginClass.Translation.ActiveTranslation.SpawnMessage.Replace("\\n", "\n"));
        }

        public override void DeSpawn()
        {
            Player.DisplayInfo = string.Empty;
            Player.AddDisplayInfo(PlayerInfoArea.Role);
        }
    }
}
