using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour
{
    public GameObject Dagger;
    public float HitCoolDown;
    public float DamageOnHit;
    public float knockBack;

    private Animator DaggerAnim;
    private BoxCollider2D DaggerColl;
    private DaggerColDetection DaggerDtct;
    private CombatSystem combatSstm;

    private bool isOnCoolDown;

    void Start()
    {
        DaggerAnim = gameObject.GetComponent<Animator>();
        DaggerColl = gameObject.GetComponent<BoxCollider2D>();
        DaggerDtct = FindObjectOfType<DaggerColDetection>();
        combatSstm = FindObjectOfType<CombatSystem>();
    }

    void Update()
    {

        DaggerColl.enabled = DaggerDtct.isTriggered;

        if (combatSstm.currentWeapon != combatSstm.Dagger)
            Destroy(gameObject);
    }


    public void StartStabAnimation()
    {
        if (isOnCoolDown == false)
        {
            DaggerAnim.SetTrigger("Stab");
            isOnCoolDown = true;
            Invoke("resetCoolDown", HitCoolDown);
        }
    }

    private void resetCoolDown()
    {
        isOnCoolDown = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && collision.GetComponent<HealthSystem>().DamageGap == false)
        {
            var enemyHp = collision.GetComponent<HealthSystem>();
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();

            Vector2 difference = collision.transform.position - gameObject.transform.position;
            difference = difference.normalized * knockBack;

            if (!enemyHp.DamageGap)
                enemy.AddForce(difference, ForceMode2D.Impulse);

            enemyHp.DealDamege(DamageOnHit);


        }
    }



}
