using Godot;
using System;
using Test.Monster.domain;

public partial class main : Node2D
{
    private MonsterServer monsterServer;

    private int first { set; get; } = 1;

    public override void _Ready()
    {
        monsterServer = new MonsterServer();
    }

    public override void _Process(double delta)
    {
        var i = new Random().Next(1, 1000);
        if (first == 1 || i <5)
        {
            var monster = monsterServer.RandomMonster();
            monster.randomPostion(GetViewportRect().Size);
            AddChild(monster);
            first++;
        }
    }
}