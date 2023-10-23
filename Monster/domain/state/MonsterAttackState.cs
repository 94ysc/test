using Test.Core.Base.status;

namespace Test.Monster.domain.state;

public class MonsterAttackState:PersonaState<Monster>
{
    public MonsterAttackState(Monster persona, PersonaStateMachine<Monster> personaStateMachine) : base(persona, personaStateMachine)
    {
    }
}