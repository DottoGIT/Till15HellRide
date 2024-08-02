using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public GameObject firepoint;
    public float Accuracy;
    public int BulletsFired;
    private BulletController bulletCntr;
    public float ShootRate;
    public float BulletSpeed;
    public float damage;
    public float knockback;
    private bool canShoot = true;

    private Animator anim;
    private Transform FireTrans;
    private CombatSystem combatSstm;
    private int i = 0;
    private bool canShootAnotherBullet = true;

    void Start()
    {
        FireTrans = firepoint.transform;
        player = FindObjectOfType<PlayerMovement>().gameObject;
        anim = gameObject.GetComponent<Animator>();
        combatSstm = FindObjectOfType<CombatSystem>();
        bulletCntr = bullet.GetComponent<BulletController>();
        bulletCntr.speed = BulletSpeed;
        bulletCntr.damage = damage;
        bulletCntr.knockBack = knockback;
    }


    void Update()
    {

        if (combatSstm.currentWeapon != combatSstm.Shotgun)
            Destroy(gameObject);

    }

    public void StartShotAnim()
    {
        if (canShoot)
        {
            anim.SetTrigger("Shoot");

            for (int i = 0; i < BulletsFired; i++)
            Instantiate(bullet, FireTrans.position, Quaternion.Euler(0, 0, FireTrans.rotation.eulerAngles.z + Random.Range(-Accuracy, Accuracy)));


            canShoot = false;
            Invoke("restartRate", ShootRate);
        }
    }
    private void restartRate()
    {
        canShoot = true;

    }
}
