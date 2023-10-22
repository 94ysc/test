using Godot;
using System;
using Test.Core.Base;
using Test.Core.Base.status;
using Test.Player.domain.status;
namespace Test.Player.domain;
public partial class Player : Persona
{
    #region 状态

    public PersonaStateMachine<Player> StateMachine { set; get; }

    public PlayerIdleState IdleState { set; get; }
    public PlayerAttackState AttackState { set; get; }
    public PlayerRunState RunState { set; get; }

    #endregion

    private void Awake()
    {
        StateMachine = new();
        IdleState = new(this, StateMachine);
        AttackState = new(this, StateMachine);
        RunState = new(this, StateMachine);
    }

    public override void _Ready()
    {
        base._Ready();
        Position = new(50, GetViewportRect().Size.Y / 2);
        Rotation = 1.5f;
        speed = 500;
        Awake();
        StateMachine.Init(IdleState);
    }

    public override void _Process(double delta)
    {
        StateMachine.CurrentPersonaState.FrameUpdate(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        StateMachine.CurrentPersonaState.PhysicsUpdate(delta);
    }
}