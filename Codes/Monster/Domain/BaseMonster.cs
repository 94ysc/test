using System;
using System.Collections.Generic;
using Godot;
using ShengChao.Codes.Monster.Domain.state;
using ShengChao.Codes.persona;


namespace ShengChao.Codes.Monster.Domain;

public partial class BaseMonster : Persona
{
    #region 状态

    public PersonaStateMachine<BaseMonster> StateMachine { set; get; }

    public MonsterIdleState IdleState { set; get; }
    public MonsterAttackState AttackState { set; get; }
    public MonsterRunState RunState { set; get; }

    public MonsterWoundedState WoundedState { set; get; }

    public bool IsHatred { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    #endregion

    public string Phase { set; get; }

    public string TargetPhase { set; get; }

    public List<string>  HostilePhase=new();

    #region 随机移动

    public float RandomMovementRange = 200f;

    public float RandomMovementSpeed = 5f;

    #endregion

    public Vector2 _targetPos;

    public override void _Ready()
    {
    }

    public void init()
    {
        StateMachine = new();
        IdleState = new(this, StateMachine);
        AttackState = new(this, StateMachine);
        RunState = new(this, StateMachine);
        WoundedState = new(this, StateMachine);
        MaxHealth = 10;
        StateMachine.Init(IdleState);
        Speed = 120;
        base.init();
    }

    public override void Move(Vector2 moveVelocity, double delta)
    {
        Velocity = Velocity.Lerp(moveVelocity, (float)(1 - Math.Exp(-delta * 20)));
        MoveAndSlide();
    }

    public override void Die()
    {
        throw new NotImplementedException();
    }

    public override void _Process(double delta)
    {
        StateMachine.CurrentPersonaState.FrameUpdate(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        StateMachine.CurrentPersonaState.PhysicsUpdate(delta);
    }

    public void SetInitPosition(Vector2 valueLocalPosition)
    {
        GlobalPosition = valueLocalPosition;
        init();
    }
}