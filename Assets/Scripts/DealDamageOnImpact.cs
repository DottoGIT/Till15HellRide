using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnImpact : MonoBehaviour
{
    public float damage;
    private HealthSystem whatIsOnFire;
    private bool isUnderAttack;

    void Start()
    {
    }
    

    void Update()
    {
        if (isUnderAttack)
            whatIsOnFire.DealDamege(damage * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" || collider.tag == "Enemy") 
        {
            whatIsOnFire = collider.gameObject.GetComponent<HealthSystem>();
            isUnderAttack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player" || collider.tag == "Enemy")
            isUnderAttack = false;
    }


}
