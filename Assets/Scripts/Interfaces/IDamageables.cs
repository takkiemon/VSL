using UnityEngine;

public interface IDamageables
{
    
}
public interface IDamageables<T>
{
    void TakeDamage(T damage);
    void Heal(T healAmount);
    bool IsAlive();
    T GetCurrentHealth();
    T GetMaxHealth();
}