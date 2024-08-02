using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperController : MonoBehaviour
{

    public GameObject bullet;
    public GameObject firepoint;
    private BulletController bulletCntr;
    public float ShootRate;
    public float BulletSpeed;
    public float damage;
    public float knockback;
    private bool canShoot = true;

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

        if (combatSstm.currentWeapon != combatSstm.Sniper)
            Destroy(gameObject);
    }

    public void StartShotAnim()
    {
        if (canShoot)
        {
            anim.SetTrigger("Shoot");
            Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation);
            canShoot = false;
            Invoke("restartRate", ShootRate);
        }
    }

    private void restartRate()
    {
        canShoot = true;
    }

}
