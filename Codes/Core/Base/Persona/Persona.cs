using System;
using Godot;

namespace ShengChao.Codes.persona;

public abstract partial class Persona : CharacterBody2D, IDamageable, IMoveable
{
    [Export] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }

    public bool IsFacingRight { get; set; }

    public float Speed { get; set; } = 150;

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

    public virtual void Move(Vector2 move_velocity, double delta)
    {
        var direction = move_velocity.Normalized();
        var targetVelocity = direction * Speed;
        Velocity = Velocity.Lerp(targetVelocity, (float)(1 - Math.Exp(-delta * 25)));
        MoveAndSlide();
    }

    public void CheckBoundary(Vector2 vector2)
    {
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