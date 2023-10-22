using Godot;
using Test.Core.Base;
using Test.Core.Base.status;

namespace Test.Player.domain.status;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player persona, PersonaStateMachine<Player> personaStateMachine) : base(persona,
        personaStateMachine)
    {
    }

    public override void EnterState()
    {
       GD.Print("进入静止");
    }

    public override void ExitState()
    {
        GD.Print("结束静止");
    }

  
}