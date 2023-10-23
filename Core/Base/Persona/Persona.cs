using Godot;
using Test.Player.domain.interfaces;

namespace Test.Core.Base;

public abstract partial  class Persona : CharacterBody2D, IDamageable, IMoveable
{
    [Export] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }

    public bool IsFacingRight { get; set; }

    public float speed;

    public override void _Ready()
    {
        init();
    }

    #region 初始化人物

    public void init()
    {
        CurrentHealth = MaxHealth;
    }

    #endregion

    #region 健康/死亡方法

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public abstract void Die();
   

    #endregion

    #region 移动方法

    public void Move(Vector2 velocity)
    {   Velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
        Position += Velocity;
        CheckBoundary(Position);
    }

    public void CheckBoundary(Vector2 vector2)
    {
        if (vector2.X < 50)
        {
            Position= new (50,vector2.Y);
        }

        if (vector2.X > 300)
        {
            Position= new (300,vector2.Y);
        }

        if (vector2.Y < 50)
        {
            Position= new (vector2.X,50);
        }

        if (vector2.Y > (GetViewportRect().Size.Y - 50))
        {
            Position= new (vector2.X,GetViewportRect().Size.Y - 50);
        }
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
    }

    #endregion
    #region 动画触发

    private void AnimationTriggerEvent(AnimationTriggerType animationTriggerType)
    {
    }

    public enum AnimationTriggerType
    {
        
    }

    #endregion
}