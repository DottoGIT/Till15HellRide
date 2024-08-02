using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TnTController : MonoBehaviour
{
    public float fireRate;
    public float damage;
    public float knockBack;
    public GameObject LayingTnt;
    public GameObject Particle;
    public GameObject FirePoint;

    private LayingTnTController ltc;
    private Animator anim;
    private CombatSystem combatSstm;
    bool isReloading;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        combatSstm = FindObjectOfType<CombatSystem>();
        ltc = LayingTnt.GetComponent<LayingTnTController>();
        ltc.Particle = Particle;
        ltc.damage = damage;
        ltc.knockBack = knockBack;

    }



    void Update()
    {
        if (combatSstm.currentWeapon != combatSstm.TNT)
            Destroy(gameObject);
    }


    public void StartPutAnim()
    {
        if (!isReloading)
        {
            anim.SetBool("Put", true);
            Invoke("StopPutAnim", 0.2f);
            isReloading = true;
            Instantiate(LayingTnt,FirePoint.transform.position,FirePoint.transform.rotation);
            Invoke("reload", fireRate);
        }
    }

    private void StopPutAnim()
    {
        anim.SetBool("Put", false);

    }

    private void reload()
    {
        isReloading = false;
    }

}
