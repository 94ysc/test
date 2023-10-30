using Godot;
using System;
using ShengChao.Codes.persona;
using ShengChao.Codes.Player.Domain.status;

namespace ShengChao.Codes.Player.Domain;

public partial class Player : Persona
{
    #region 状态

    public PersonaStateMachine<Player> StateMachine { set; get; }

    public PlayerIdleState IdleState { set; get; }
    public PlayerAttackState AttackState { set; get; }
    public PlayerRunState RunState { set; get; }

    #endregion

    public override void _Ready()
    {
        Speed = 500;
        StateMachine = new();
        IdleState = new(this, StateMachine);
        AttackState = new(this, StateMachine);
        RunState = new(this, StateMachine);
        StateMachine.Init(IdleState);
    }

    public override void Move(Vector2 velocity, double delta)
    {
        base.Move(velocity, delta);
        StateMachine.ChangeState(RunState);
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
}