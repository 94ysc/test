using Godot;
using ShengChao.Codes.persona;


namespace ShengChao.Codes.Monster.Domain.state;

public class MonsterRunState : PersonaState<BaseMonster>
{
    private Vector2 _direction=Vector2.Zero;
    public MonsterRunState(BaseMonster persona, PersonaStateMachine<BaseMonster> personaStateMachine) : base(persona,
        personaStateMachine)
    {
    }

    public override void EnterState()
    {
        GD.Print("run");
    }

    public override void ExitState()
    {
    }

    public override void FrameUpdate(double delta)
    {
        _direction = (persona._targetPos - persona.Position).Normalized();
        persona.Move(_direction * persona.Speed, delta);
        if (persona.GlobalPosition.DistanceTo(persona._targetPos)<1)
        {
            persona.StateMachine.ChangeState(persona.IdleState);
        }
    }
}