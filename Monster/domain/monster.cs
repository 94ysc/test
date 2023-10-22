using Godot;
using System;

public partial class monster : CharacterBody2D
{
    public override void _Ready()
    {
        Position = new(GetViewportRect().Size.X, 400);
    }

    public override void _Process(double delta)
    {
        Position += Vector2.Left*(float)2;
    }

}