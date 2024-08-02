using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float timeToNextSlowDown;
    public float slowMultiplier;
    private Rigidbody2D objectRig;

    void Start()
    {
        objectRig = gameObject.GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        Invoke("slowDown", timeToNextSlowDown);
    }

    private void slowDown()
    {
        objectRig.velocity = new Vector2(objectRig.velocity.x - objectRig.velocity.x/ slowMultiplier, objectRig.velocity.y - objectRig.velocity.y/ slowMultiplier);
    }
}
