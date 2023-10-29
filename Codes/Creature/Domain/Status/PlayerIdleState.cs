using ShengChao.Codes.persona;
namespace ShengChao.Codes.Player.Domain.status;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player persona, PersonaStateMachine<Player> personaStateMachine) : base(persona,
        personaStateMachine)
    {
    }

    public override void EnterState()
    {
       // GD.Print("进入静止");
    }

    public override void ExitState()
    {
        // GD.Print("结束静止");
    }

  
}