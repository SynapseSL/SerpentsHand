using Synapse.Config;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace SerpentsHand
{
    public class PluginConfig : AbstractConfigSection
    {
        [Description("If friendlyfire for serpentshand is active")]
        public bool Friendlyfire { get; set; } = false;

        [Description("The role that serpentshand will look like")]
        public RoleType SpawnRole { get; set; } = RoleType.Tutorial;

        [Description("The Health of SerpentsHand members")]
        public float Health { get; set; } = 120;

        [Description("The Role Name that is displayed when you look at the Player")]
        public string CustomRoleName { get; set; } = "SerpentsHand";

        [Description("The chance that a SerpentsHand Squad spawns instead of a Chaos")]
        public float SpawnChance { get; set; } = 50f;

        [Description("The Cassie announcement that plays when SerpentsHand Spawn")]
        public string Cassie { get; set; } = "serpents hand hasentered allremaining";

        [Description("The Spawnpoint where SerpentsHand spawn")]
        public SerializedMapPoint SpawnPoint { get; set; } = new SerializedMapPoint("Outside", -0.4426118f, 2.159119f, 7.987663f);

        [Description("The maximal amount of players that can spawn as SerpentsHand in one squad")]
        public int SpawnSize { get; set; } = 7;

        public SerializedPlayerInventory Inventory { get; set; } = new SerializedPlayerInventory
        {
            Ammo = new SerializedAmmo
            {
                Ammo5 = 40,
                Ammo7 = 40,
                Ammo9 = 30,
                Ammo12 = 14,
                Ammo44 = 18
            },
            Items = new List<SerializedPlayerItem>
            {
                new SerializedPlayerItem((int)ItemType.KeycardChaosInsurgency,0f,0u,Vector3.one,100,false),
                new SerializedPlayerItem((int)ItemType.Medkit,0f,0u,Vector3.one,100,false),
                new SerializedPlayerItem((int)ItemType.GunLogicer,100f,0u,Vector3.one,100,false),
                new SerializedPlayerItem((int)ItemType.Painkillers,0f,0u,Vector3.one,100,false)
            }
        };
    }
}
