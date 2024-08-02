using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayingTnTController : MonoBehaviour
{
    public float damage;
    public float knockBack;
    public GameObject Particle;
    private DestroyAfterTime destAftTime;

     void Start()
    {
        destAftTime = gameObject.GetComponent<DestroyAfterTime>();
        Invoke("spawnParticle", destAftTime.TimeToDeath - 0.1f);
    }


    private void OnTriggerEnter2D(Collider2D obj)
    {
         if(obj.CompareTag("Enemy"))
         {
             var enHp = obj.gameObject.GetComponent<HealthSystem>();
             enHp.DealDamege(damage);
             enHp.knockBack(knockBack, gameObject);
         }

         if (obj.CompareTag("Player"))
        {
            var enHp = obj.gameObject.GetComponent<HealthSystem>();
            enHp.DealDamege(damage);
            enHp.knockBack(knockBack, gameObject);
        }

    }

    private void spawnParticle()
    {
        Instantiate(Particle, gameObject.transform.position, gameObject.transform.rotation);
    }

}
