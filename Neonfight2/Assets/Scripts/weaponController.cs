using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject sword;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;

    public AudioClip SwordAttackClip;
    public AudioClip SwordSpecialAttackClip;


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
        // Start cooldown
        CanAttack = false;

        // Trigger attack animation
        Animator swordAnimator = sword.GetComponent<Animator>();
        swordAnimator.SetTrigger("attack");
            print("Sword Attack!");
        AudioSource ac = GetComponent<AudioSource>();
        ac.clip = SwordAttackClip;
        
        StartCoroutine(ResetAttackCooldown());
        //Invoke(nameof(ResetAttack), AttackCooldown);
    }

    public void SpecialSwordAttack()
    {
        // Start cooldown
        CanAttack = false;

        // Trigger attack animation
        Animator swordAnimator = sword.GetComponent<Animator>();
        swordAnimator.SetTrigger("specialAttack");
            print("Sword special Attack!");
        AudioSource ac = GetComponent<AudioSource>();
        ac.clip = SwordSpecialAttackClip;

        StartCoroutine(ResetAttackCooldown());

    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(1.0f);
        CanAttack = true;

    }


}



