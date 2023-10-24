using UnityEngine;

namespace MOBA
{
    public class TestDummy : MonoBehaviour, IDamageable
    {
        public int maxHealth = 5000;
        public int currentHealth = 5000;
        public float secondsToResetHealth = 5;
        private float timeOfDamage = 0;

        public void Damage(int damage)
        {
            currentHealth -= damage;
            timeOfDamage = Time.time;
        }

        private void Update()
        {
            if (Time.time > timeOfDamage + secondsToResetHealth)
                currentHealth = maxHealth;
        }
    }
}