using System.ComponentModel;
using System.Collections.Generic;
using Synapse.Config;
using UnityEngine;

namespace SerpentsHand
{
    public class PluginConfig : AbstractConfigSection
    {
        [Description("If friendlyfire for serpentshand is active")]
        public bool friendlyfire = false;

        [Description("The role that serpentshand will look like")]
        public RoleType SpawnRole = RoleType.Tutorial;

        [Description("The Health of SerpentsHand members")]
        public int Health = 120;

        [Description("The Role Name that is displayed when you look at the Player")]
        public string CustomRoleName = "<color=green>SerpentsHand</color>";

        [Description("The chance that a SerpentsHand Squad spawns instead of a Chaos")]
        public float SpawnChance = 50f;

        [Description("The Cassie announcement that plays when SerpentsHand Spawn")]
        public string Cassie = "serpents hand hasentered allremaining";

        [Description("The Spawnpoint where SerpentsHand spawn")]
        public SerializedMapPoint SpawnPoint = new SerializedMapPoint("Root_*&*Outside Cams", -0.4426118f, 2.159119f, 7.987663f);

        [Description("The amount of ammo that SerpentsHand spawns with")]
        public Ammo Ammo = new Ammo();

        [Description("The maximal amount of players that can spawn as SerpentsHand in one squad")]
        public int SpawnSize = 7;

        [Description("The items that Serpentshand spawn with")]
        public List<SerializedItem> Items = new List<SerializedItem>
        {
            new SerializedItem((int)ItemType.KeycardChaosInsurgency,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Medkit,0,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.GunLogicer,75,0,0,0,Vector3.one),
            new SerializedItem((int)ItemType.Painkillers,0,0,0,0,Vector3.one)
        };
    }

    public class Ammo
    {
        public uint Ammo5 = 50;

        public uint Ammo7 = 50;

        public uint Ammo9 = 50;
    }
}
