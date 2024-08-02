using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatUpgradeItIs : MonoBehaviour
{
    public int whichPanel;
    public int whichUpgrade;
    public bool instantActiv = false;

    private LayingWeapons lW;
    private CombatSystem cS;


    void Start()
    {
        lW = FindObjectOfType<LayingWeapons>();
        cS = FindObjectOfType<CombatSystem>();
    }
    
    void Update()
    {
        if(instantActiv)
        {
            cS.timeToSwitch = true;

            if (whichPanel == 1)
                lW.Panel1Lvl = whichUpgrade;

            if (whichPanel == 2)
                lW.Panel2Lvl = whichUpgrade;

            if (whichPanel == 3)
                lW.Panel3Lvl = whichUpgrade;

            if (whichPanel == 4)
                lW.Panel4Lvl = whichUpgrade;

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !instantActiv)
        {
            cS.timeToSwitch = true;

            if(whichPanel == 1)
                lW.Panel1Lvl=whichUpgrade;

            if (whichPanel == 2)
                lW.Panel2Lvl = whichUpgrade;

            if (whichPanel == 3)
                lW.Panel3Lvl = whichUpgrade;

            if (whichPanel == 4)
                lW.Panel4Lvl = whichUpgrade;

            Destroy(gameObject);
        }
    }
}
