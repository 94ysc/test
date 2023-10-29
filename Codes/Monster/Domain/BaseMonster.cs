using System;
using Godot;
using ShengChao.Codes.Domain.checks;
using ShengChao.Codes.Monster.Domain.checks;
using ShengChao.Codes.Monster.Domain.state;
using ShengChao.Codes.persona;


namespace ShengChao.Codes.Monster.Domain;

public partial class BaseMonster : Persona, MonsterHatredCheck
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

    #region 随机移动

    public float RandomMovementRange = 100f;

    public float RandomMovementSpeed = 10f;

    #endregion

    public Vector2 _targetPos;

    public override void _Ready()
    {
        StateMachine = new();
        IdleState = new(this, StateMachine);
        AttackState = new(this, StateMachine);
        RunState = new(this, StateMachine);
        WoundedState = new(this, StateMachine);
        StateMachine.Init(IdleState);
        MaxHealth = 10;
        init();
        //仇恨吸引
        foreach (var child in GetChildren())
        {
            if (child.Name == "HatredCheck")
            {
                ((Area2D)child).AreaEntered += HateAttracts;
            }
        }
    }

    public override void Move(Vector2 velocity, double delta)
    {
        Velocity = velocity * (float)delta;
        CheckForLeftOrRightFacing(velocity);
        Position += Velocity;
        CheckBoundary(Position);
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
        StateMachine.Init(IdleState);
    }

    public void HateAttracts(Area2D area2D)
    {
        if (area2D.Name == "Beaten"&&area2D.GetParent() is CharacterBody2D persona)
        {
            _targetPos = persona.Position;
            StateMachine.Init(RunState);
        }
    }
}