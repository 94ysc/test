using Godot;

namespace ShengChao.Codes.Monster.Domain.checks;

/// <summary>
/// 攻击距离
/// </summary>
public partial class MonsterStrikingDistanceCheck:Area2D
{
    public override void _Ready()
    {
        AreaEntered += Striking;
    }

    public void Striking(Area2D area2D)
    {
        if (GetParent() is not BaseMonster monster)
        {
            return;
        }

        if (area2D.Name == "Beaten")
        {
            monster._targetPos = area2D.GlobalPosition;
        }

        if (!area2D.GetParent().IsInGroup("monster")) return;
        if (area2D.GetParent() is not BaseMonster targetMonster) return;
        if (monster.TargetPhase == targetMonster.Phase)
        {
            targetMonster.QueueFree();
        }
    }
}