using Godot;
using ShengChao.Codes.Core.Util;
using ShengChao.Codes.persona;

namespace ShengChao.Codes.Monster.Domain.state;

public class MonsterIdleState : PersonaState<BaseMonster>
{
    private Vector2 _targetPos;

    private Vector2 _direction;

    public MonsterIdleState(BaseMonster persona, PersonaStateMachine<BaseMonster> personaStateMachine) : base(persona,
        personaStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        GD.Print("idle");
        _targetPos = GetRandomPointInCircle();
    }

    private Vector2 GetRandomPointInCircle()
    {
        return persona.GlobalPosition + RandomUtil.insidenCircle() * persona.RandomMovementRange;
    }

    public override void FrameUpdate(double delta)
    {
        _direction = (_targetPos - persona.Position).Normalized();
        persona.Move(_direction * persona.RandomMovementSpeed, delta);
        if (persona.GlobalPosition.DistanceTo(_targetPos)<1)
        {
            _targetPos = GetRandomPointInCircle();
        }
    }
}