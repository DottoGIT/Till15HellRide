using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    private Text TimePassed;

    private int Sec = 0;
    private int Min=15;
    private bool isWaiting;
    private string SSec;
    private string SMin;
    public int x;
    public int y;


    void Start()
    {
        TimePassed = gameObject.GetComponent<Text>();
    }
    void Update()
    {
        if(!isWaiting)
        {
            Invoke("AddSecond", 1f + 1-Time.timeScale);
            isWaiting = true;
        }
        if(Sec == -1)
        {
            Min--;
            Sec = 59;
        }

        if (Sec < 10)
        {
            SSec = "0" + Sec.ToString();
        }
        else
            SSec = Sec.ToString();

        if (Min < 10)
        {
            SMin = "0" + Min.ToString();
        }
        else
            SMin = Min.ToString();


        if (Input.GetButton("PauseMenu")){
            TimePassed.rectTransform.position = new Vector3(867, 1053, 0f);
            TimePassed.CrossFadeAlpha(1f, 0, false);



        }
        else
        {
            TimePassed.CrossFadeAlpha(0.5f, 0, false);

            TimePassed.rectTransform.position = new Vector3(120, 164, 0f);
        }



        TimePassed.text = SMin + ":" + SSec;
    }

    private void AddSecond()
    {
        Sec--;
        isWaiting = false;
    }


}
