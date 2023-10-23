using Godot;

namespace Test.Monster.domain.checks;

/// <summary>
/// 被击检测
/// </summary>
public interface MonsterAttackedCheck
{
    void attacked(Area2D area2D);
}