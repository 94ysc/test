using Godot;

namespace ShengChao.Codes.persona;

public abstract partial class Persona : CharacterBody2D, IDamageable, IMoveable
{
    [Export] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }

    public bool IsFacingRight { get; set; }

    public float Speed { get; set; } = 100;

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

    public virtual void Move(Vector2 velocity, double delta)
    {
        Velocity = velocity.Normalized() * Speed * (float)delta;
        CheckForLeftOrRightFacing(velocity);
        Position += Velocity;
        CheckBoundary(Position);
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