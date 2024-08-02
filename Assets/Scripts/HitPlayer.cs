using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{

    public float damage;
    public float knockBack;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !collision.gameObject.GetComponent<HealthSystem>().DamageGap)
        {
            collision.gameObject.GetComponent<HealthSystem>().DealDamege(damage);
            collision.gameObject.GetComponent<HealthSystem>().knockBack(knockBack,gameObject);
        }
    }
}
