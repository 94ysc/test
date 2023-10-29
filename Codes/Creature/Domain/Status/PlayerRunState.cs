using ShengChao.Codes.persona;


namespace ShengChao.Codes.Player.Domain.status;

public class PlayerRunState : PlayerState
{
    public PlayerRunState(Player persona, PersonaStateMachine<Player> personaStateMachine) : base(persona,
        personaStateMachine)
    {
    }

    public override void EnterState()
    {
        // GD.Print("开始运动");
    }

    public override void ExitState()
    {
        // GD.Print("结束运动");
    }

 
}