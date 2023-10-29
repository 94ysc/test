

using ShengChao.Codes.persona;

namespace ShengChao.Codes.Monster.Domain.state;

public class MonsterAttackState:PersonaState<BaseMonster>
{
    public MonsterAttackState(BaseMonster persona, PersonaStateMachine<BaseMonster> personaStateMachine) : base(persona, personaStateMachine)
    {
    }
}