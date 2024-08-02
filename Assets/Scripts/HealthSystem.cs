using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health;
    public float timeBetweenDamageTaken;
    public Transform healthBar;
    public ParticleSystem DeathPart;
    public GameObject BloodStain;
    public bool isKillable;
    public bool DamageGap = false;

    private ShamanScript ShmScrpt;
    public float healthNow;

    void Start()
    {
        healthNow = health;
    }
    

    void Update()
    {
        try
        {
            ShmScrpt = FindObjectOfType<ShamanScript>();
        }
        catch { }


        if (healthNow > health)
            healthNow = health;
        if (healthNow < 0)
            healthNow = 0;
        try
        { healthBar.localScale = new Vector3(healthNow / health, healthBar.localScale.y, healthBar.localScale.z); }
        catch { }

        if (healthNow <= 0 && isKillable)
        {
            if (DeathPart != null)
                Instantiate(DeathPart, gameObject.transform.position, gameObject.transform.rotation);

            Instantiate(BloodStain, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        try
        {
            if (ShmScrpt.isHealing && !gameObject.CompareTag("Player"))
            {
                SelfHeal();
            }
        }
        catch { }
    }

    public void DealDamege(float damegeDelt)
    {
            healthNow -= damegeDelt;
            DamageGap = true;
            Invoke("DamageGapCounter", timeBetweenDamageTaken);
        
    }

    public void HealDamege(float damegeDelt)
    {
        healthNow += damegeDelt;

    }

    private void DamageGapCounter()
    {
        DamageGap = false;
    }


    public void knockBack(float knockBackValue, GameObject whereAreYou)
    {
        Rigidbody2D enemy = gameObject.GetComponent<Rigidbody2D>();
        Vector2 difference = gameObject.transform.position - whereAreYou.transform.position;
        difference = difference.normalized * knockBackValue;
        enemy.AddForce(difference, ForceMode2D.Impulse);
    }

    private void SelfHeal()
    {
        HealDamege(ShmScrpt.HealValue);
        Instantiate(ShmScrpt.healPartforEnemies, gameObject.transform.position, gameObject.transform.rotation);
    }

}
