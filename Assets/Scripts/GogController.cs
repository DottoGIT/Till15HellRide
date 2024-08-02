using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class GogController : MonoBehaviour
{
    public GogTriggerZone GTZ;
    public GameObject FireBall;
    public GameObject FirePoint;
    public GameObject GogBody;
    private GameObject plr;
    public float ChargeTime;
    public float AttackSpeed;

    private AIPath PathFnd;
    private Animator anim;
    private Rigidbody2D Rg;
    private bool isShooting = false;
    private bool canShoot;

    void Start()
    {
        plr = FindObjectOfType<PlayerMovement>().gameObject;
        Rg = gameObject.GetComponent<Rigidbody2D>();
        PathFnd = gameObject.GetComponent<AIPath>();
        anim = gameObject.GetComponent<Animator>();
        canShoot = true;
    }

    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("GogStun"))
        {
            isShooting = false;
        }


        if (GTZ.isInTheZone || isShooting)
        {
            StopAndAim();
        }
        else if(!isShooting)
        {
            PathFnd.enabled = true;
            anim.SetBool("Charge", false);
            anim.SetBool("IsWalking", true);
            Rg.constraints = RigidbodyConstraints2D.None;
        }

        RotateToPlayer();
    }

    

    private void StopAndAim()
    {
        if(!gameObject.GetComponent<HealthSystem>().DamageGap)
        isShooting = true;
        Rg.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        PathFnd.enabled = false;
        anim.SetBool("IsWalking", false);
        anim.SetBool("Charge", true);
        Invoke("Shoot", ChargeTime);
    }


    private void RotateToPlayer()
    {
        Vector3 difference = plr.transform.position - gameObject.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        GogBody.transform.rotation = Quaternion.Euler(0f, 0f, (rotZ - 90));
    }

    private void Shoot()
    {
        if (canShoot && anim.GetCurrentAnimatorStateInfo(0).IsName("GogShoot"))
        {
            Instantiate(FireBall, FirePoint.transform.position, FirePoint.transform.rotation);
            canShoot = false;
            Invoke("ResetShoot", AttackSpeed);
        }
    }
    private void ResetShoot()
    {
        canShoot = true;
    }
}
