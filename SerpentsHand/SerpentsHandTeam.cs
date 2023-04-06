using System.Collections.Generic;
using Neuron.Core.Meta;
using Ninject;
using Synapse3.SynapseModule.Enums;
using Synapse3.SynapseModule.Map;
using Synapse3.SynapseModule.Player;
using Synapse3.SynapseModule.Teams;
using UnityEngine;

namespace SerpentsHand;

[Automatic]
[Team(
    Id = 7,
    Name = "SerpentsHand"
    )]
public class SerpentsHandTeam : SynapseTeam
{
    [Inject]
    public SerpentsHand Plugin { get; set; }
    
    [Inject]
    public CassieService Cassie { get; set; }
    
    public string LastSpawnUnit { get; set; }

    public override void SpawnPlayers(List<SynapsePlayer> players)
    {
        LastSpawnUnit = Plugin.Config.UnitNames[Random.Range(1, Plugin.Config.UnitNames.Count)] + "-" +
                        Random.Range(0, 21).ToString("00");
        
        var count = players.Count;
        var privates = (count - 1) / 3;
        for (int i = 0; i < count; i++)
        {
            var player = players[i];
            if (i == 0)
            {
                player.RoleID = 32;
                continue;
            }

            if (i <= privates)
            {
                player.RoleID = 31;
                continue;
            }

            player.RoleID = 30;
        }
    }

    public override int MaxWaveSize => Plugin.Config.SpawnSize;

    //I use 15 since it is close the Chaos/Mtf and Plugins can better predict when the respawn actually happens
    public override float RespawnTime => 15f;

    public override void RespawnAnnouncement()
    {
        Cassie.Announce(Plugin.Config.Cassie, CassieSettings.Noise, CassieSettings.Glitched);
    }
}
