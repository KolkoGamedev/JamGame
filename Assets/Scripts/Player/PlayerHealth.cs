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
        if (health < maxHealth)
        {
            health += value;
            OnHealthChanged(health);
            OnHeal(value);
        }
    }

    public void TakeDamage(int value)
    {
        if (!playerShield.isShielded)
        {
            OnHit(value);
            health -= value;
        }  
        else
        {
            playerShield.UnShield();
            OnHit(0);
        }
            

        if (health <= 0)
        {
            OnDie();
            playerDeath();
        }
            
    }

    private void playerDeath()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<TrailRenderer>().Clear();
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

