using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class DemonController : MonoBehaviour
{
    public DTriggerZone TriggerZone;
    public GameObject DBody;
    public GameObject DeathPart;
    public GameObject DeathPartFinisher;
    public GameObject BloodStain;
    public int chance;
    public int DashSpeed;
    public float dashLenght;
    public float dashPrep;

    private GameObject Player;
    private Rigidbody2D Rig2D;
    private CapsuleCollider2D cpsCol;
    private Animator anim;
    private bool doDash = false;
    private bool timeToShuffle = true;
    private bool canDash = true;
    private bool didDie;
    private AIPath pathFndr;
    private HealthSystem hlthsys;
    public GameObject healthBar;


    void Start()
    {
        Rig2D = gameObject.GetComponent<Rigidbody2D>();
        hlthsys = gameObject.GetComponent<HealthSystem>();
        cpsCol = gameObject.GetComponent<CapsuleCollider2D>();
        Player = FindObjectOfType<PlayerMovement>().gameObject;
        anim = gameObject.GetComponent<Animator>();
        pathFndr = gameObject.GetComponent<AIPath>();
    }


    void Update()
    {
        if (!didDie)
        {

            if (!doDash)
                cpsCol.enabled = false;
            else
                cpsCol.enabled = true;

            if (timeToShuffle && !doDash)
            { Invoke("Shuffle", 2f); timeToShuffle = false; }

            if (TriggerZone.isInTheZone && doDash && canDash)
            {
                pathFndr.canMove = false;
                anim.SetTrigger("StartDashPrep");
                Invoke("StartDash", dashPrep);
                canDash = false;

            }

            if (hlthsys.healthNow <= 0)
            {
                cpsCol.enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                anim.Play("DemonDeath");
                Destroy(healthBar);
                pathFndr.enabled = false;
                Rig2D.freezeRotation = true;
                Rig2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                Instantiate(DeathPart, gameObject.transform.position, gameObject.transform.rotation);
                Invoke("Disappear", 5f);
                didDie = true;
            }

        }
    }


    private void RotateToPlayer()
    {
        Vector3 difference = Player.transform.position - gameObject.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        DBody.transform.rotation = Quaternion.Euler(0f, 0f, (rotZ - 90));
    }

    private void Shuffle()
    {
        int number;
        number = Random.Range(1, 11);


        if (number <= chance)
            doDash = true;

        timeToShuffle = true;
    }

    private void StartDash()
    {
        if (!didDie)
        {
            Invoke("StopDash", 2f);
            anim.SetTrigger("Dash");
            pathFndr.canSearch = false;
            pathFndr.canMove = true;
            pathFndr.maxSpeed = DashSpeed;
        }
    }

    private void StopDash()
    {
        if (!didDie)
        {
            anim.SetTrigger("EndDash");
            Invoke("StartRotating", 0.25f);
            doDash = false;
            canDash = true;
            pathFndr.maxSpeed = 1.5f;
        }

    }

    private void StartRotating()
    {
        if (!didDie)
        {
            pathFndr.canSearch = true;
            pathFndr.canMove = true;
        }
    }

    private void Disappear()
    {
        Destroy(gameObject);
        Instantiate(DeathPartFinisher, gameObject.transform.position, gameObject.transform.rotation);
        Instantiate(BloodStain, gameObject.transform.position, gameObject.transform.rotation);


    }

}
