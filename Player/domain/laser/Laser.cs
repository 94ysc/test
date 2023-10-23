using Godot;
using System;
using Test.Monster.domain;
using Test.Player.domain.laser;

public partial class Laser : Area2D, LaserAttackedCheck
{
    private double timeDlta = 1;

    public float harm = 1;

    public override void _Process(double delta)
    {
        Position += Vector2.Up * (float)delta * 1000;
        timeDlta -= delta;
        if (timeDlta <= 0)
        {
            QueueFree();
        }
    }


    public void attacked(Area2D area2D)
    {
        if (area2D.Name.Equals("monsterArea"))
        {
            QueueFree();
        }
    }
}