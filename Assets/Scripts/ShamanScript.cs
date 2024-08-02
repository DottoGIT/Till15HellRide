using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ShamanScript : MonoBehaviour
{
    public GogTriggerZone zoneController;
    public GameObject healPart;
    public GameObject healPartforEnemies; 
    public float healFrequency;
    public bool isHealing;
    public float HealValue;

    private GameObject player;
    private AIDestinationSetter destSetter;
    private Animator anim;

    private bool canInvoke = true;


    public GameObject wayPoint;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
        destSetter = gameObject.GetComponent<AIDestinationSetter>();
    }

    void Update()
    {
        if (zoneController.isInTheZone)
        {
            Vector2 difference = player.transform.position - gameObject.transform.position;
            difference = difference.normalized * 5;
            difference = -difference;
            wayPoint.transform.position = difference + new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            anim.SetBool("CantHeal", true);
            isHealing = false;
        }
        else
        {
            wayPoint.transform.position = gameObject.transform.position;
            anim.SetBool("CantHeal", false);
            anim.SetTrigger("StartHealing");

            if (canInvoke)
            {
                Invoke("InstHeal", healFrequency);
                isHealing = false;
                canInvoke = false;
            }
        }
    }

    private void InstHeal()
    {
        canInvoke = true;
        Instantiate(healPart, gameObject.transform.position, gameObject.transform.rotation);
        isHealing = true;
    }
}
