using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaScript : MonoBehaviour
{
    public bool canRun = true;
    public GameObject Bar;
    public float staminaLossNormal;
    public float staminaLossWithKnife;
    public float staminaGain;

    private CombatSystem combatSystem;
    private float staminaNow = 100;
    private bool canRegenerate = true;
    private float staminaLoss;

    void Start()
    {
        combatSystem = FindObjectOfType<CombatSystem>();
        staminaLoss = staminaLossNormal;
    }

    void Update()
    {
        if (combatSystem.currentWeapon == combatSystem.Dagger)
            staminaLoss = staminaLossWithKnife;
        else staminaLoss = staminaLossNormal;

        if (Input.GetAxisRaw("Jump") > 0)
        {
            staminaNow -= staminaLoss * Time.deltaTime;
            canRegenerate = false;
        }
        else
            canRegenerate = true;

        if (canRegenerate)
        {
            staminaNow += staminaGain * Time.deltaTime;
        }



        if (staminaNow <= 0)
        {
            staminaNow = 0;
            canRun = false;
        }

        if (staminaNow > 0)
            canRun = true;


        if (staminaNow >= 100)
            staminaNow = 100;


       Bar.transform.localScale = new Vector3(staminaNow / 100, Bar.transform.localScale.y, Bar.transform.localScale.z);

    }
}
