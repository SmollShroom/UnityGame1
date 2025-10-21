using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public weaponController wp;
    public GameObject HitParticle; 

        void ontriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
               other.GetComponent<Animator>().SetTrigger("hit");        //important that every 
        }
    }
}
