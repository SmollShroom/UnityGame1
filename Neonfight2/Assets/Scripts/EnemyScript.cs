using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float Enemy_MaxHealth = 10f;
    public float Enemy_CurrentHealth ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy_CurrentHealth = Enemy_MaxHealth;
    }

    public void TakeDamage(float damageAmount)
        {
            Enemy_CurrentHealth -= damageAmount;
            if (Enemy_CurrentHealth <= 0)
            {
                Die();
            }
        }
        public void Die()
        {
            // Play death animation or effects here
            Destroy(gameObject); // Remove enemy from the scene
        }



    

    // Update is called once per frame
    void Update()
    {
        
    }
}
