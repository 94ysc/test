using Godot;
using Test.Core.Base;
using Test.Core.Base.status;

namespace Test.Player.domain.status;

public class PlayerAttackState:PlayerState
{
    public PlayerAttackState(Player persona, PersonaStateMachine<Player> personaStateMachine) : base(persona, personaStateMachine)
    {
    }
    
    public override void EnterState()
    {
     GD.Print("开始攻击");
    }

    public override void ExitState()
    {
        GD.Print("结束攻击");
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