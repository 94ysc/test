using Godot;
using Test.Core.Base;
using Test.Core.Base.status;


namespace Test.Player.domain.status;

public abstract class PlayerState : PersonaState<Player>
{
    public PlayerState(Player persona, PersonaStateMachine<Player> personaStateMachine) : base(persona,
        personaStateMachine)
    {
    }

    public override void PhysicsUpdate(double delta)
    {
        var targetVector = Input.GetVector("LEFT", "RIGHT", "UP", "DOWN");
        if (targetVector != Vector2.Zero)
        {
            persona.Move(targetVector * (float)(persona.speed * delta));
            personaStateMachine.ChangeState(persona.RunState);
            return;
        }
        
        personaStateMachine.ChangeState(persona.IdleState);
    }
}