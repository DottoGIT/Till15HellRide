using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainGen : MonoBehaviour
{
    public GameObject BloodStain1;
    public GameObject BloodStain2;
    public GameObject BloodStain3;
    public int BiggestPossible;
    public int lowestPossible;
    private GameObject visibleStain;
    private float size;

    void Start()
    {
        DrawStain();
        size = DrawSize();
        visibleStain.transform.localScale = new Vector3(size, size, size);
    }


    private void DrawStain()
    {
        int r;
        r = Random.Range(1, 4);

        switch (r)
        {
            case 1: BloodStain1.SetActive(true); visibleStain = BloodStain1; break;
            case 2: BloodStain2.SetActive(true); visibleStain = BloodStain2; break;
            case 3: BloodStain3.SetActive(true); visibleStain = BloodStain3; break;
        }
    }

    private float DrawSize()
    {
        return Random.Range(1.64668f, 0.9943644f);
    }

}
