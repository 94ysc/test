using System;
using System.Linq;
using Godot;
using ShengChao.Codes.Monster.ACL.Client.Repository;
using ShengChao.Codes.Monster.Domain;
using ShengChao.Codes.Player.Domain;
using ShengChao.Codes.Word.Domain.Map;

namespace ShengChao.Codes.Word.Domain;

public partial class Word : Node2D
{
    private Map.Map map;

    public override void _Ready()
    {
        addMap();
        addPlayer();
        addMonster();
    }

    private void addMonster()
    {
        foreach (var keyValuePair in map.mapBlocks)
        {
            if (!keyValuePair.Value.isCollide && keyValuePair.Value.isMonsterFarming)
            {
                if (new Random().Next(1, 100) < 50)
                {
                    MonsterServer monsterServer = new MonsterServer();
                    var monster = monsterServer.RandomMonster();
                    monster.GlobalPosition = keyValuePair.Value.localPostion + new Vector2I(35, 40);
                    AddChild(monster);
                }
            }
        }
    }

    public override void _Process(double delta)
    {
    }

    private void addPlayer()
    {
        var player = new PlayerFactory().createPlayer();
        player.GlobalPosition = new Vector2(map._width / 2, map._height / 2);
        AddChild(player);
    }

    public void addMap()
    {
        map = new MapFactory().createRandomMap();
        AddChild(map);
    }
}