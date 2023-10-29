using Godot;
using ShengChao.Codes.persona;


namespace ShengChao.Codes.Monster.Domain.state;

public class MonsterRunState : PersonaState<BaseMonster>
{
    public MonsterRunState(BaseMonster persona, PersonaStateMachine<BaseMonster> personaStateMachine) : base(persona,
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
        // persona.Position +=persona.Velocity*(float)delta*50;
    }
}