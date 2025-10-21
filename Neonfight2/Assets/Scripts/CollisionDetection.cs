using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public weaponController wc;
    public GameObject HitParticle;

    private void OntriggerEnter(Collider other)
    {
<<<<<<< Updated upstream
        Debug.Log(other.name);

        if (other.tag=="enemy") //&& wc.isAttacking
=======
        if (other.tag == "enemy")
>>>>>>> Stashed changes
        {
            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("hit");        //important that every enemy has an animator with a "hit" trigger

            Instantiate(HitParticle, new Vector3(other.transform.position.x, 
                transform.position.y, 
                other.transform.position.z),
                other.transform.rotation);

        }
    }
}
