using Godot;

namespace Test.Monster.domain;

public class MonsterServer
{
    public Monster RandomMonster()
    {
        var monsterScene = GD.Load<PackedScene>("res://Monster/scene/monster.tscn");
        var monster = monsterScene.Instantiate<Monster>();
        return monster;
    }
}