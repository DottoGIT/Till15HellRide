using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float sprintSpeed;
    public float SlowOnPause;
    public GameObject pMenu;

    private float originalMovSpeed;
    private Rigidbody2D rgidbody;
    private CameraAttach barAttach;
    private StaminaScript stamina;
    

    void Start()
    {
        stamina = FindObjectOfType<StaminaScript>();
        originalMovSpeed = movementSpeed;
        sprintSpeed += movementSpeed;
        rgidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, (rotZ + 90));


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rgidbody.velocity = new Vector2(movementSpeed * Time.deltaTime, rgidbody.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rgidbody.velocity = new Vector2(-movementSpeed * Time.deltaTime, rgidbody.velocity.y);
        }
             else if(!gameObject.GetComponent<HealthSystem>().DamageGap)
             {
                 rgidbody.velocity = new Vector2(0, rgidbody.velocity.y);
             }
             if (Input.GetAxisRaw("Vertical") < 0)
        {
            rgidbody.velocity = new Vector2(rgidbody.velocity.x, (-movementSpeed) * Time.deltaTime);
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            rgidbody.velocity = new Vector2(rgidbody.velocity.x, movementSpeed * Time.deltaTime);
        }
            else if (!gameObject.GetComponent<HealthSystem>().DamageGap)
            {
                rgidbody.velocity = new Vector2(rgidbody.velocity.x, 0);
            }

        if (Input.GetAxisRaw("Jump") > 0 && stamina.canRun)
         {
             movementSpeed = sprintSpeed;
         }
               else
               {
                   movementSpeed = originalMovSpeed;
               }

        if (Input.GetButton("PauseMenu"))
        {
            pMenu.SetActive(true);
            Time.timeScale = SlowOnPause;
        }
        else
        {
            pMenu.SetActive(false);
            Time.timeScale = 1f;

        }




    }


}
