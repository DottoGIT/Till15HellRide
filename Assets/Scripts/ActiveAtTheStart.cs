using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAtTheStart : MonoBehaviour
{
    public SpriteRenderer Bar;
    public SpriteRenderer Background;
    public SpriteRenderer Border;

    void Start()
    {
        Bar.enabled = Background.enabled = Border.enabled = true;
    }
}
