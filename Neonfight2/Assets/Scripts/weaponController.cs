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

    public bool isAttacking = false;
    public bool isSpecialAttacking = false;

    public float RecourcesMax = 5f;
    public float Resources;
    public float RecourcesNeeded = 1f;

    [SerializeField]
    private GameObject ResourceMonitor;
    private ResourceMonitorScript _resourceMonitorScript;

    void Start()
    {
        Resources = RecourcesMax;

        // Cache the ResourceMonitor component from the GameObject
        if (ResourceMonitor != null)
        {
            _resourceMonitorScript = ResourceMonitor.GetComponent<ResourceMonitorScript>();
            _resourceMonitorScript.SetMaxResources(RecourcesMax);

            if (_resourceMonitorScript == null)
                Debug.LogWarning("ResourceMonitor component not found on GameObject");
        }
        else
        {
            print("ResourceMonitor GameObject reference is null");
        }
    }

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
        isAttacking = true;
        CanAttack = false;

        // Trigger attack animation
        Animator swordAnimator = sword.GetComponent<Animator>();
        swordAnimator.SetTrigger("attack");
        //print("Sword Attack!");
        AudioSource ac = GetComponent<AudioSource>();
        ac.clip = SwordAttackClip;

        StartCoroutine(ResetAttackCooldown());
        //Invoke(nameof(ResetAttack), AttackCooldown);

        if (Resources < RecourcesMax)
        {
            Resources += 1f;
                // Safely call the method on the LiveCounter component
                if (_resourceMonitorScript != null)
                {
                    // Replace AdjustImageWidth with the actual public method name in LiveCounter
                    _resourceMonitorScript._AdjustSlider(Resources);
                }
        }

    }

    public void SpecialSwordAttack()
    {
        
        if (Resources >= RecourcesNeeded)
        {
            Resources -= RecourcesNeeded;

            isSpecialAttacking = true;
            CanAttack = false;

            // Trigger attack animation
            Animator swordAnimator = sword.GetComponent<Animator>();
            swordAnimator.SetTrigger("specialAttack");
            //print("Sword special Attack!");
            AudioSource ac = GetComponent<AudioSource>();
            ac.clip = SwordSpecialAttackClip;

                // Safely call the method on the LiveCounter component
                if (_resourceMonitorScript != null)
                {
                // Replace AdjustImageWidth with the actual public method name in LiveCounter
                _resourceMonitorScript._AdjustSlider(Resources);
                }

            StartCoroutine(ResetAttackCooldown());
        }
        else { 
            print("Not enough resources for special attack!"); 
        }



    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;

    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
        isSpecialAttacking = false;
    }


}



