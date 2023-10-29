namespace ShengChao.Codes.persona;

public interface IDamageable
{
    float MaxHealth { set; get; }
    float CurrentHealth { set; get; }

    void Damage(float damageAmount);
    
    void Die();
}