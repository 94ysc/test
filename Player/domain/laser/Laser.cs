using Godot;
using System;

public partial class Laser : Area2D
{
    private double timeDlta=1;
    public override void _Process(double delta)
    {
        Position += Vector2.Up*(float)delta*1000;
        timeDlta-=delta;
        if (timeDlta <= 0)
        {
            this.QueueFree();
        }
    }
}