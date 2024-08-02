using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHealthBar : MonoBehaviour
{
    public SpriteRenderer HealtBarBackground;
    public SpriteRenderer HealtBarTheme;
    public SpriteRenderer HealtBar;

    public float showTime;
    private bool canInvoke = true;

    void Start()
    {
        SetEverythingAs(false);
    }

    void Update()
    {
        if (gameObject.GetComponent<HealthSystem>().DamageGap)
        {
            SetEverythingAs(true);
            if (canInvoke)
            {
                Invoke("DesactivateHealthBar", showTime);
                canInvoke = false;
            }
        }
    }

    private void DesactivateHealthBar()
    {
        SetEverythingAs(false);
        canInvoke = true;
    }

    private void SetEverythingAs(bool ans)
    {
        try
        {
            HealtBar.enabled = ans;
            HealtBarTheme.enabled = ans;
            HealtBarBackground.enabled = ans;
        }
        catch { }
    }
}
