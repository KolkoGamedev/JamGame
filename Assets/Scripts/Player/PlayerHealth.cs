using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, IHealable, IDamagable
    {
        public static event Action<int> OnHealthChanged = delegate { };
        public static event Action<int> OnHeal = delegate { };
        public static event Action<int> OnHit = delegate { };
        public static event Action<string> OnDie = delegate { };

        public int health = 3;
        public int maxHealth = 3;

        private IShieldable playerShield;

        private void Awake()
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
            if (!playerShield.IsShielded)
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
                OnDie(SceneManager.GetActiveScene().name);
                PlayerDeath();
            }
            
        }

        private void PlayerDeath()
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


}
