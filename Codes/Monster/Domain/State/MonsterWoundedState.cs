using Godot;
using ShengChao.Codes.persona;


namespace ShengChao.Codes.Monster.Domain.state;

public class MonsterWoundedState : PersonaState<BaseMonster>
{
    public MonsterWoundedState(BaseMonster persona, PersonaStateMachine<BaseMonster> personaStateMachine) : base(persona,
        personaStateMachine)
    {
    }

    public override void EnterState()
    {

    }
}