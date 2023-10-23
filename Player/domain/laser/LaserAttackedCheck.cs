using Godot;

namespace Test.Player.domain.laser;

public interface LaserAttackedCheck
{
    void attacked(Area2D area2D);
}