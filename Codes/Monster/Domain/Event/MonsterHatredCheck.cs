using Godot;
using ShengChao.Codes.Monster.Domain;

namespace ShengChao.Codes.Domain.checks;

/// <summary>
/// 怪物仇恨检测
/// </summary>
public partial class MonsterHatredCheck : Area2D
{
    private bool _flag;

    public override void _Ready()
    {
        AreaEntered += Statr;
        AreaExited += End;
    }

    public void Statr(Area2D area2D)
    {
        _flag = true;
    }

    public void End(Area2D area2D)
    {
        _flag = false;
    }

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

    public override void _Process(double delta)
    {
        if (_flag)
        {
            HateAttracts();
        }
    }
}