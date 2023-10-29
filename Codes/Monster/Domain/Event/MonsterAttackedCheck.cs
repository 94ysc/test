using Godot;

namespace ShengChao.Codes.Monster.Domain.checks;

/// <summary>
/// 被击检测
/// </summary>
public interface MonsterAttackedCheck
{
    void attacked(Area2D area2D);
}