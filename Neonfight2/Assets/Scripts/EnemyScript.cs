using System.Collections;
using System.Collections.Generic;
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
            GetComponentInChildren<Animator>().SetTrigger("dead");
            StartCoroutine(WaitForAnimation(2));

    }



    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForAnimation(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }


}
