using System;
using Godot;
using ShengChao.Codes.Monster.Domain.checks;
using ShengChao.Codes.Monster.Domain.state;
using ShengChao.Codes.persona;


namespace ShengChao.Codes.Monster.Domain;

public partial class BaseMonster : Persona
{
    #region 状态

    public PersonaStateMachine<BaseMonster> StateMachine { set; get; }

    public MonsterIdleState IdleState { set; get; }
    public MonsterAttackState AttackState { set; get; }
    public MonsterRunState RunState { set; get; }

    public MonsterWoundedState WoundedState { set; get; }

    public bool IsHatred { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    #endregion

        
    public virtual void _Ready()
    {
        StateMachine = new();
        IdleState = new(this, StateMachine);
        AttackState = new(this, StateMachine);
        RunState = new(this, StateMachine);
        WoundedState = new(this, StateMachine);
        StateMachine.Init(IdleState);
        MaxHealth = 10;
        init();
    }

    public override void Die()
    {
        throw new NotImplementedException();
    }


}