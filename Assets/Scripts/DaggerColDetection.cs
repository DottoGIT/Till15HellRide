using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerColDetection : MonoBehaviour
{
    public bool isTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            isTriggered = true;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            isTriggered = false;
        }
    }

}
