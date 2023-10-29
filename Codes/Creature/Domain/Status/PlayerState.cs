using Godot;
using ShengChao.Codes.persona;


namespace ShengChao.Codes.Player.Domain.status;

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
            persona.Move(targetVector,delta);
        }
        personaStateMachine.ChangeState(persona.IdleState);
    }
}