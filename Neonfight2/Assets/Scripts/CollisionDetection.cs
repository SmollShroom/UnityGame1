using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wp;
    public GameObject HitParticle; 

        void ontriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
               other.GetComponent<Animator>().SetTrigger("hit");
        }
    }
}
