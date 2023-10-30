using System;
using System.Linq;
using Godot;
using ShengChao.Codes.Monster.ACL.Client.Repository;
using ShengChao.Codes.Monster.Domain;
using ShengChao.Codes.Player.Domain;
using ShengChao.Codes.Word.ACL.Adapter.Repository;
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
        MonsterServer monsterServer = new MonsterServer();
        while (true)
        {
            foreach (var keyValuePair in map.mapBlocks)
            {
                if (!keyValuePair.Value.isCollide && keyValuePair.Value.isMonsterFarming)
                {
                    if (new Random().Next(1, 100) < 50)
                    {
                        var monster = monsterServer.RandomMonster(keyValuePair.Value.localPostion + new Vector2I(35, 40));
                        AddChild(monster);
                        if (MonsterRepository.BaseMonsters.Count >= 1000)
                        {
                            return;
                        }
                    }
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