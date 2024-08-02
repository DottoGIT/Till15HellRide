using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firepoint;
    public GameObject PistolMain;
    private BulletController bulletCntr;
    public float ShootRate;
    public float BulletSpeed;
    public float damage;
    public float knockback;
    private bool canShoot=true;

    private Animator anim;
    private CombatSystem combatSstm;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        combatSstm = FindObjectOfType<CombatSystem>();
        bulletCntr = bullet.GetComponent<BulletController>();
        bulletCntr.speed = BulletSpeed;
        bulletCntr.damage = damage;
        bulletCntr.knockBack = knockback;
    }


    void Update()
    {

        if (combatSstm.currentWeapon != combatSstm.Pistol)
            Destroy(PistolMain);
    }

    public void StartShotAnim()
    {
        if (canShoot)
        {
            anim.SetBool("Shoot", true);
            Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation);
            Invoke("StopShotAnim", 0.2f);
            canShoot = false;
            Invoke("restartRate", ShootRate);
        }
    }
    public void StopShotAnim()
    {
        anim.SetBool("Shoot", false);
    }
    private void restartRate()
    {
        canShoot = true;

    }

}
