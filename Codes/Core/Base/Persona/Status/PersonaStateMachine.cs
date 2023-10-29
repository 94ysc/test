namespace ShengChao.Codes.persona;

public class PersonaStateMachine<T> where T : Persona
{
    public PersonaState<T> CurrentPersonaState { set; get; }

    public void Init(PersonaState<T> startState)
    {
        CurrentPersonaState = startState;
        CurrentPersonaState.EnterState();
    }

    public void ChangeState(PersonaState<T> newState)
    {
        if (CurrentPersonaState == newState) return;
        CurrentPersonaState.ExitState();
        CurrentPersonaState = newState;
        CurrentPersonaState.EnterState();
    }
}