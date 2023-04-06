using System.Collections.Generic;
using Neuron.Core.Meta;
using Ninject;
using PlayerRoles;
using Synapse3.SynapseModule;
using Synapse3.SynapseModule.Enums;
using Synapse3.SynapseModule.Role;

namespace SerpentsHand;

public abstract class SerpentsHandRole : SynapseAbstractRole
{
    [Inject]
    public SerpentsHand Plugin { get; set; }
    
    public SerpentsHandTeam ShTeam { get; set; }
    
    protected Config.SHConfig _config;
    protected override IAbstractRoleConfig GetConfig() => _config;

    public override List<uint> GetFriendsID() => Plugin.Config.FriendlyFire
        ? new List<uint> { (uint)Team.SCPs }
        : new List<uint> { (uint)Team.SCPs, 7 };

    public override List<uint> GetEnemiesID() => new List<uint> { (uint)Team.ClassD, (uint)Team.FoundationForces, (uint)Team.Scientists };

    protected override void PreSpawn()
    {
        ShTeam ??= Synapse.Get<SerpentsHandTeam>();
        _config.CustomUnitName = ShTeam.LastSpawnUnit;
    }
}

[Automatic]
[Role(
    Id = 30,
    Name = "SerpentsHand Cadet",
    TeamId = 7
)]
public class SerpentsHandCadet : SerpentsHandRole
{
    public override void Load() => _config = Plugin.Config.CadetConfig;
    
    protected override void OnSpawn(IAbstractRoleConfig config)
    {
        if (Player.PlayerType != PlayerType.Dummy)
            Player.SendWindowMessage(Plugin.Translation.Get(Player).SpawnMessageCadet.Replace("\\n", "\n"));
    }
}

[Automatic]
[Role(
    Id = 31,
    Name = "SerpentsHand Private",
    TeamId = 7
)]
public class SerpentsHandPrivate : SerpentsHandRole
{
    public override void Load() => _config = Plugin.Config.PrivateConfig;
    
    protected override void OnSpawn(IAbstractRoleConfig config)
    {
        if (Player.PlayerType != PlayerType.Dummy)
            Player.SendWindowMessage(Plugin.Translation.Get(Player).SpawnMessagePrivate.Replace("\\n", "\n"));
    }
}

[Automatic]
[Role(
    Id = 32,
    Name = "SerpentsHand Sergeant",
    TeamId = 7
)]
public class SerpentsHandSergeant : SerpentsHandRole
{
    public override void Load() => _config = Plugin.Config.SergeantConfig;
    
    protected override void OnSpawn(IAbstractRoleConfig config)
    {
        if (Player.PlayerType != PlayerType.Dummy)
            Player.SendWindowMessage(Plugin.Translation.Get(Player).SpawnMessageSergeant.Replace("\\n", "\n"));
    }
}
