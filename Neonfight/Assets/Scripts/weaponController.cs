using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject sword;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;



    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanAttack)
        {
            SwordAttack();
        }
        if (Input.GetMouseButtonDown(1) && CanAttack)
        {
            SpecialSwordAttack();
        }
    }

    public void SwordAttack()
    {
        // Trigger attack animation
        Animator swordAnimator = sword.GetComponent<Animator>();
        swordAnimator.SetTrigger("attack");
            
            //print("Sword Attack!");

        //// Start cooldown
        //CanAttack = false;
        ////Invoke(nameof(ResetAttack), AttackCooldown);
    }
    public void SpecialSwordAttack()
    {
        // Trigger attack animation
        Animator swordAnimator = sword.GetComponent<Animator>();
        swordAnimator.SetTrigger("specialAttack");

        //print("Sword Attack!");

        //// Start cooldown
        //CanAttack = false;
        ////Invoke(nameof(ResetAttack), AttackCooldown);
    }

    // numerator ResetAttack()
    // yield return  new WaitCooldown(AttackCooldown);
    //CanAttack = true;

    //}
}
