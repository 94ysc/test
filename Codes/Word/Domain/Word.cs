using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using ShengChao.Codes.Monster.ACL.Client.Repository;
using ShengChao.Codes.Monster.Domain;
using ShengChao.Codes.Player.Domain;
using ShengChao.Codes.Word.ACL.Adapter.Repository;
using ShengChao.Codes.Word.Domain.Map;
using ShengChao.Codes.Word.Domain.Map.MapBlock;

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
        var mapBlocks = (from keyValuePair in map.mapBlocks
            where !keyValuePair.Value.isCollide && keyValuePair.Value.isMonsterFarming
            select keyValuePair.Value).ToList();
        var index = new Random().Next(0, mapBlocks.Count);
        var monster = monsterServer.RandomMonster(mapBlocks[index].localPostion + new Vector2I(35, 40));
        AddChild(monster);
    }

    public override void _Process(double delta)
    {
        if (MonsterRepository.BaseMonsters.Count < 1000)
        {
            addMonster();
        }
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