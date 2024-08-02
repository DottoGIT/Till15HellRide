using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttach : MonoBehaviour
{
    public GameObject player;
    public Vector3 PositionFromPlayer;
    public float CameraSize;
    public bool followPlayer;

    private Camera cmera;


    void Start()
    {

        try
        {
            cmera = GetComponent<Camera>();
            cmera.orthographicSize = CameraSize;
        }
        catch { }
        if (followPlayer)
            player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update()
    {
        try
        { cmera.transform.position = new Vector3(player.transform.position.x + PositionFromPlayer.x, player.transform.position.y + PositionFromPlayer.y, player.transform.position.z + PositionFromPlayer.z);
        }catch
        {
          gameObject.transform.position = new Vector3(player.transform.position.x + PositionFromPlayer.x, player.transform.position.y + PositionFromPlayer.y, player.transform.position.z + PositionFromPlayer.z);
        }

    }
}
