using Godot;
using Test.Core.Base;
using Test.Core.Base.status;
using Test.Monster.domain.checks;
using Test.Monster.domain.interfaces;
using Test.Monster.domain.state;

namespace Test.Monster.domain;

public partial class Monster : Persona, ITriggerCheckable, MonsterAttackedCheck
{
    #region 状态

    public PersonaStateMachine<Monster> StateMachine { set; get; }

    public MonsterIdleState IdleState { set; get; }
    public MonsterAttackState AttackState { set; get; }
    public MonsterRunState RunState { set; get; }

    public MonsterWoundedState WoundedState { set; get; }

    public bool IsHatred { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    #endregion

    public override void _Ready()
    {
        StateMachine = new();
        IdleState = new(this, StateMachine);
        AttackState = new(this, StateMachine);
        RunState = new(this, StateMachine);
        WoundedState = new(this, StateMachine);
        StateMachine.Init(RunState);
        MaxHealth = 10;
        init();
    }

    public override void _Process(double delta)
    {
        StateMachine.CurrentPersonaState.FrameUpdate(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        StateMachine.CurrentPersonaState.PhysicsUpdate(delta);
    }


    #region 随机位置

    public void randomPostion(Vector2 vector2)
    {
        var y = new Random().Next(50, (int)(vector2.Y - 50));
        Position = new(vector2.X, y);
    }

    #endregion


    #region 距离检测

    public void SetHatredStatue(bool isHatred)
    {
        IsHatred = isHatred;
    }

    public void SetStrikingDistance(bool isWithinStrikingDistance)
    {
        IsWithinStrikingDistance = isWithinStrikingDistance;
    }

    #endregion

    #region 被击检测

    public void attacked(Area2D area2D)
    {
        if (area2D is Laser laser)
        {
            Damage(laser.harm);
            StateMachine.ChangeState(WoundedState);
        }
    }

    public override void Die()
    {
        QueueFree();
    }

    #endregion
}