using Godot;
using Test.Core.Base;
using Test.Core.Base.status;

namespace Test.Monster.domain.state;

public class MonsterRunState : PersonaState<Monster>
{
    public MonsterRunState(Monster persona, PersonaStateMachine<Monster> personaStateMachine) : base(persona,
        personaStateMachine)
    {
    }

    public override void EnterState()
    {
    }

    public override void ExitState()
    {
    }

    public override void FrameUpdate(double delta)
    {
        persona.Position += Vector2.Left*(float)delta*50;
    }
}