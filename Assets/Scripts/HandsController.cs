using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour
{
    public float damageOnHit;
    public float knockBack;
    public float Cooldown;

    private Animator anim;
    private CombatSystem CmbSs;
    private bool isOnCooldown;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        CmbSs = FindObjectOfType<CombatSystem>();
    }
    
    void Update()
    {
        if (CmbSs.currentWeapon != CmbSs.bareHands)
            Destroy(gameObject);
    }

    public void RightPunch()
    {
        if (!isOnCooldown)
        {
            anim.SetTrigger("RPunch");
            isOnCooldown = true;
            Invoke("ResetCooldown", Cooldown);
        }
    }
    public void LeftPunch()
    {
        if (!isOnCooldown)
        {
            anim.SetTrigger("LPunch");
            isOnCooldown = true;
            Invoke("ResetCooldown", Cooldown);
        }
    }

    private void ResetCooldown()
    {
        isOnCooldown = false;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.CompareTag("Enemy"))
        {
            var EnHp = obj.GetComponent<HealthSystem>();
            EnHp.DealDamege(damageOnHit);
            EnHp.knockBack(knockBack, gameObject);
        }
    }
}
