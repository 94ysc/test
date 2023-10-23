using Test.Core.Base.status;

namespace Test.Monster.domain.state;

public class MonsterIdleState:PersonaState<Monster>
{
    public MonsterIdleState(Monster persona, PersonaStateMachine<Monster> personaStateMachine) : base(persona, personaStateMachine)
    {
    }
}