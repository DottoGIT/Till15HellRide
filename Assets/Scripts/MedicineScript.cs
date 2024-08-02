using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineScript : MonoBehaviour
{
    public float healValue;
    public int MedNr = 0;
    public bool HandsPrefab;

    private HealthSystem player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().GetComponent<HealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!HandsPrefab && collision.CompareTag("Player"))
        {
           if (player.healthNow + healValue >= player.health)
           {
               gameObject.AddComponent<WhatUpgradeItIs>();
               var WUII = gameObject.GetComponent<WhatUpgradeItIs>();
               WUII.whichPanel = 4;
               WUII.whichUpgrade = MedNr;
               WUII.instantActiv = true;
           }

           else if (collision.tag == "Player" && player.healthNow != player.health)
            {
                InstantHeal();
                Destroy(gameObject);
            }
        }
    }
    public void InstantHeal()
    {
        player.DealDamege(-healValue);
    }

}
