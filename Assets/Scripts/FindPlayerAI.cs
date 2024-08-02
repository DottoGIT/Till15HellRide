using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FindPlayerAI : MonoBehaviour
{
    public GameObject Player;
    public bool doesntHaveDamageAnim;
    private Transform plrTrn;
    private AIPath PathFnd;
    private HealthSystem hltsSystm;
    private Animator anim;

    void Start()
    {
        Player = FindObjectOfType<PlayerMovement>().gameObject;
        anim = gameObject.GetComponent<Animator>();
        plrTrn = FindObjectOfType<PlayerMovement>().gameObject.transform;
        PathFnd = gameObject.GetComponent<AIPath>();
        hltsSystm = gameObject.GetComponent<HealthSystem>();
        var AiDest = gameObject.GetComponent<AIDestinationSetter>();
        AiDest.target = plrTrn;
    }


    private void Update()
    {
        if (!doesntHaveDamageAnim)
        {
            if (hltsSystm.DamageGap)
            {
                PathFnd.enabled = false;
                anim.SetBool("DamageCap", true);
            }
            else
            {
                PathFnd.enabled = true;
                anim.SetBool("DamageCap", false);
            } }
    }
}
