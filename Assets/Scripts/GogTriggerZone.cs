using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GogTriggerZone : MonoBehaviour
{
    public bool isInTheZone;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInTheZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isInTheZone = false;
    }

}
