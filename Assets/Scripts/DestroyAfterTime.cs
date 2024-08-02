using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float TimeToDeath;

    void Start()
    {
        Invoke("Destroy", TimeToDeath);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
