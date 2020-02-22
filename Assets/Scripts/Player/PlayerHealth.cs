using UnityEngine;
using System;
public class PlayerHealth : MonoBehaviour, IHealable, IDamagable
{
    public static event Action<int> OnHealthChanged = delegate { };
    public static event Action<int> OnHeal = delegate { };
    public static event Action<int> OnHit = delegate { };
    public static event Action OnDie = delegate { };

    public int health = 3;
    public int maxHealth = 3;

    private IShieldable playerShield;

    void Awake()
    {
        playerShield = GetComponent<IShieldable>();
    }

    public void Heal(int value)
    {
        OnHealthChanged(health);
        OnHeal(value);
        
        if (health < maxHealth)
            health += value;
    }

    public void TakeDamage(int value)
    {
        if (!playerShield.isShielded)
        {
            OnHit(value);
            health -= value;
        }  
        else
            playerShield.UnShield();

        if (health <= 0)
            OnDie();
    }
    private void OnDestroy()
    {
        OnHeal = delegate { };
        OnHealthChanged = delegate { };
        OnHit = delegate { };
        OnDie = delegate { };
    }
}

public interface IDamagable
{
    void TakeDamage(int value);
}

public interface IHealable
{
    void Heal(int value);
}

