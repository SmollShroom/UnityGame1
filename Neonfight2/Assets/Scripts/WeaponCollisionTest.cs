using UnityEngine;

public class WeaponCollisionTest : MonoBehaviour
{

    public weaponController wc;
    public float WeaponDamage = 0f;
    public float WeaponSpecialDamage = 0f;

    public float ResourceNeeded = 0f;

    public GameObject HitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (wc.isAttacking)
        {
           
                    //Debug.Log("Weapon Collision: " + other.name);

            if (other.tag == "enemy" && wc.isAttacking)
            {
                Debug.Log("Weapon HIT: " + other.name);
                other.GetComponentInChildren<Animator>().SetTrigger("hit");         //important that every enemy has an animator with a "hit" trigger
                Debug.Log("Animator component: " + other.GetComponentInChildren<Animator>().name);
                        //other.GetComponent<Animator>().SetTrigger("hit");        //important that every enemy has an animator with a "hit" trigger

                other.GetComponent<EnemyScript>().TakeDamage(WeaponDamage);
                        // other.GetComponent("EnemyScript");
                        // Debug.Log("EnemyScript component: " + other.GetComponent("EnemyScript"));

                //Particles
                Instantiate(HitParticle, new Vector3(other.transform.position.x,
                transform.position.y,
                other.transform.position.z),
                other.transform.rotation);
            }
        }

        if (wc.isSpecialAttacking)
        {
            if (other.tag == "enemy" && wc.isSpecialAttacking)
            {
                Debug.Log("Weapon SPECIAL HIT: " + other.name);
                other.GetComponentInChildren<Animator>().SetTrigger("hit");         //important that every enemy has an animator with a "hit" trigger
                Debug.Log("Animator component: " + other.GetComponentInChildren<Animator>().name);
                other.GetComponent<EnemyScript>().TakeDamage(WeaponSpecialDamage);
             
                //Particles
                Instantiate(HitParticle, new Vector3(other.transform.position.x,
                transform.position.y,
                other.transform.position.z),
                other.transform.rotation);
            }
        }

    }

}
