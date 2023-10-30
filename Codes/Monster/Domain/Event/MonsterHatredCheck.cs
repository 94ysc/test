using Godot;
using ShengChao.Codes.Monster.Domain;

namespace ShengChao.Codes.Domain.checks;

/// <summary>
/// 怪物仇恨检测
/// </summary>
public partial class MonsterHatredCheck : Area2D
{
    public override void _Ready()
    {
        AreaEntered += HateAttracts;
        AreaExited += NotHateAttracts;
    }

    private void NotHateAttracts(Area2D area2D)
    {
        if (GetParent() is not BaseMonster monster)
        {
            return;
        }

        if (area2D.Name != "Beaten" && area2D.GetParent() is not BaseMonster)
        {
            monster?.StateMachine.ChangeState(monster.IdleState);
        }
    }

    public void HateAttracts(Area2D area2D)
    {
        if (GetParent() is not BaseMonster monster)
        {
            return;
        }

        if (area2D.Name == "Beaten")
        {
            monster._targetPos = area2D.GlobalPosition;
            monster.StateMachine.ChangeState(monster.RunState);
        }

        if (!area2D.GetParent().IsInGroup("monster")) return;
        if (area2D.GetParent() is not BaseMonster targetMonster) return;
        if (monster.TargetPhase == targetMonster.Phase)
        {
            monster._targetPos = area2D.GlobalPosition;
            monster.StateMachine.ChangeState(monster.RunState);
        }

        if (!monster.HostilePhase.Contains(targetMonster.Phase)) return;
        monster._targetPos = -(monster.GlobalPosition - area2D.GlobalPosition) * 100;
        monster.StateMachine.ChangeState(monster.RunState);
    }
}