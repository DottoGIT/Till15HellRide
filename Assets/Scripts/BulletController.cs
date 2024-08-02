using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float damage;
    public float knockBack;

    public bool TriggerOnPlayer;
    public bool TriggerOnEnemy;
    public bool PassThroughEnemy = false;
    public bool isInWall;

    void Start()
    {
        Invoke("destroy", 3f);
    }

    void Update()
    {
       gameObject.transform.Translate(Vector2.down * speed * Time.deltaTime);

    }

    private void destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Enemy") && TriggerOnEnemy)
        {
            var enHp = obj.GetComponent<HealthSystem>();
            enHp.DealDamege(damage);
            enHp.knockBack(knockBack, gameObject);
            if(!PassThroughEnemy)
            Destroy(gameObject);
        }

        if (obj.CompareTag("Player") && TriggerOnPlayer)
        {
            var enHp = obj.GetComponent<HealthSystem>();
            enHp.DealDamege(damage);
            enHp.knockBack(knockBack, gameObject);
            Destroy(gameObject);
        }

        if (obj.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
