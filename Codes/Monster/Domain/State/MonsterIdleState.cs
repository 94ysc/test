
using ShengChao.Codes.persona;

namespace ShengChao.Codes.Monster.Domain.state;

public class MonsterIdleState:PersonaState<BaseMonster>
{
    public MonsterIdleState(BaseMonster persona, PersonaStateMachine<BaseMonster> personaStateMachine) : base(persona, personaStateMachine)
    {
    }
}