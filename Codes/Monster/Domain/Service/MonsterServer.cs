using System;
using System.Collections.Generic;
using Godot;
using ShengChao.Codes.Core.Config;
using ShengChao.Codes.Monster.Domain.Factory;

namespace ShengChao.Codes.Monster.Domain;

public class MonsterServer
{
    private MonsterFactory _monsterFactory = new();

    public BaseMonster RandomMonster(Vector2 postion)
    {
        return _monsterFactory.of((MonsterFactory.MonsterType)new Random().Next(0, 5),postion);
    }
}