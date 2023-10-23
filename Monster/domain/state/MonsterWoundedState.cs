using Godot;
using Test.Core.Base.status;

namespace Test.Monster.domain.state;

public class MonsterWoundedState : PersonaState<Monster>
{
    public MonsterWoundedState(Monster persona, PersonaStateMachine<Monster> personaStateMachine) : base(persona,
        personaStateMachine)
    {
    }

    public override void EnterState()
    {
        persona.Position += Vector2.Right * 10;
        var healthTitle = persona.GetNode<TextureProgressBar>("HealthTitle");
        healthTitle.MaxValue = persona.MaxHealth;
        healthTitle.Value = persona.CurrentHealth;
        persona.StateMachine.ChangeState(persona.RunState);
    }
}