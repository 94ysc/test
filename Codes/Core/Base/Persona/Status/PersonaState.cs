namespace ShengChao.Codes.persona;

public class PersonaState<T> where T:Persona
{
    protected T persona;

    protected PersonaStateMachine<T> personaStateMachine;

    public PersonaState(T persona, PersonaStateMachine<T> personaStateMachine)
    {
        this.persona = persona;
        this.personaStateMachine = personaStateMachine;
    }

    /// <summary>
    /// 进入状态
    /// </summary>
    public virtual void EnterState() { }
    /// <summary>
    /// 退出状态
    /// </summary>
    public virtual void ExitState() { }

    /// <summary>
    /// 帧更新
    /// </summary>
    /// <param name="delta"></param>
    public virtual void FrameUpdate(double delta) { }

    /// <summary>
    /// 物理更新
    /// </summary>
    /// <param name="delta"></param>
    public virtual void PhysicsUpdate(double delta) { }

    /// <summary>
    /// 动画事件
    /// </summary>
    public virtual void AnimationTriggerEvent(Persona.AnimationTriggerType triggerType)
    {
        
    }
}