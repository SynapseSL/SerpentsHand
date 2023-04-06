using System;
using System.Collections.Generic;
using System.ComponentModel;
using Neuron.Core.Meta;
using PlayerRoles;
using Syml;
using Synapse3.SynapseModule.Config;
using Synapse3.SynapseModule.Map.Rooms;
using Synapse3.SynapseModule.Role;
using UnityEngine;
using YamlDotNet.Serialization;

namespace SerpentsHand;

[Automatic]
[Serializable]
[DocumentSection("SerpentsHand")]
public class Config : IDocumentSection
{
    [Description("If friendlyfire for serpentshand is active")]
    public bool FriendlyFire { get; set; } = false;

    [Description("The chance that a SerpentsHand Squad spawns instead of a Chaos")]
    public float SpawnChance { get; set; } = 50f;

    [Description("The Cassie announcement that plays when SerpentsHand Spawn")]
    public string Cassie { get; set; } = "serpents hand hasentered allremaining";

    [Description("The maximal amount of players that can spawn as SerpentsHand in one squad")]
    public int SpawnSize { get; set; } = 7;

    public SHConfig CadetConfig { get; set; } = new();

    public SHConfig PrivateConfig { get; set; } = new();

    public SHConfig SergeantConfig { get; set; } = new();

    public List<string> UnitNames { get; set; } = new()
    {
        "Serpent",
        "Anomaly",
        "Occult",
        "ScarletKing",
        "Hand",
        "Library"
    };

    [Serializable]
    public class SHConfig : IAbstractRoleConfig
    {
        public RoleTypeId Role { get; set; } = RoleTypeId.Tutorial;
        public RoleTypeId VisibleRole { get; set; } = RoleTypeId.None;
        public RoleTypeId OwnRole { get; set; } = RoleTypeId.None;
        public uint EscapeRole { get; set; } = uint.MaxValue;
        public float Health { get; set; } = 120;
        public float MaxHealth { get; set; } = 120;
        public float ArtificialHealth { get; set; } = 0;
        public float MaxArtificialHealth { get; set; } = 75;

        public RoomPoint[] PossibleSpawns { get; set; } = new[]
        {
            new RoomPoint("Surface", new Vector3(0f,1.5f,5f), Vector3.zero)
        };

        public SerializedPlayerInventory[] PossibleInventories { get; set; } = new[]
        {
            new SerializedPlayerInventory()
            {
                Ammo = new SerializedAmmo
                {
                    Ammo5 = 0,
                    Ammo7 = 120,
                    Ammo9 = 0,
                    Ammo12 = 0,
                    Ammo44 = 0
                },
                Items = new List<SerializedPlayerItem>
                {
                    new((uint)ItemType.KeycardChaosInsurgency, 0f, 0u, Vector3.one, 100, false),
                    new((uint)ItemType.Medkit, 0f, 0u, Vector3.one, 100, false),
                    new((uint)ItemType.GunLogicer, 100f, 0u, Vector3.one, 100, false),
                    new((uint)ItemType.Painkillers, 0f, 0u, Vector3.one, 100, false),
                    new((uint)ItemType.ArmorCombat, 0f, 0u, Vector3.one, 100, false)
                }
            }
        };

        [YamlIgnore]
        public bool CustomDisplay { get; set; } = true;
        [YamlIgnore]
        public bool Hierarchy { get; set; } = true;
        [YamlIgnore]
        public bool UseCustomUnitName { get; set; } = true;
        [YamlIgnore]
        public string CustomUnitName { get; set; }

        public SerializedVector3 Scale { get; set; } = Vector3.one;

        public SHConfig Copy() => new SHConfig()
        {
            Role = Role,
            VisibleRole = VisibleRole,
            EscapeRole = EscapeRole,
            Health = Health,
            MaxHealth = MaxHealth,
            ArtificialHealth = ArtificialHealth,
            MaxArtificialHealth = MaxArtificialHealth,
            PossibleInventories = PossibleInventories,
            PossibleSpawns = PossibleSpawns,
        };
    }
}
