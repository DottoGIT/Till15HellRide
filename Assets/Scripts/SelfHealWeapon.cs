using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfHealWeapon : MonoBehaviour
{
    public GameObject Firepoint;
    public ParticleSystem HealPart;
    private Animator anim;
    private CombatSystem CmbtSs;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        CmbtSs = FindObjectOfType<CombatSystem>();
    }

    void Update()
    {
        if (CmbtSs.currentWeapon != CmbtSs.Medpack)
            Destroy(gameObject);
    }

    public void SelfHeal(float HealValue)
    {
        anim.SetTrigger("Heal");
        Instantiate(HealPart,Firepoint.transform.position,Firepoint.transform.rotation); 
        var PlrHp = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<HealthSystem>();
        PlrHp.DealDamege(-HealValue);
    }
}
