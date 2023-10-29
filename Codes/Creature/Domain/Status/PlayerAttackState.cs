using Godot;
using ShengChao.Codes.persona;


namespace ShengChao.Codes.Player.Domain.status;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player persona, PersonaStateMachine<Player> personaStateMachine) : base(persona,
        personaStateMachine)
    {
    }

    public override void EnterState()
    {
        // GD.Print("开始攻击");
    }

    public override void ExitState()
    {
        // GD.Print("结束攻击");
    }

    public override void FrameUpdate(double delta)
    {
    }

    public override void PhysicsUpdate(double delta)
    {
    }

    public override void AnimationTriggerEvent(Persona.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }
}