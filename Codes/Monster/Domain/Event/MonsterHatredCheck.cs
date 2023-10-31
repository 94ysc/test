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
        var timer = GetChild<Timer>(1);
        timer.Timeout += HateAttracts;
        timer.Start();
    }

    // private void NotHateAttracts(Area2D area2D)
    // {
    //     if (GetParent() is not BaseMonster monster)
    //     {
    //         return;
    //     }
    //
    //     if (area2D.Name != "Beaten" && area2D.GetParent() is not BaseMonster)
    //     {
    //         monster?.StateMachine.ChangeState(monster.IdleState);
    //     }
    // }


    public void HateAttracts()
    {
        if (GetParent() is not BaseMonster monster)
        {
            return;
        }

        var areaList = GetOverlappingAreas();
        foreach (var area2D in areaList)
        {
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
            if (monster.HostilePhase[0] != targetMonster.Phase &&
                monster.HostilePhase[1] != targetMonster.Phase) continue;
            monster._targetPos = monster.GlobalPosition +
                                 (monster.GlobalPosition - targetMonster.GlobalPosition).Normalized() * 100;
            monster.StateMachine.ChangeState(monster.RunState);
        }
    }
}