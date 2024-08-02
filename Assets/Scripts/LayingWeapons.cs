using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayingWeapons : MonoBehaviour
{
    public RawImage DaggerTxt;
    public RawImage PistolTxt;
    public RawImage SniperTxt;
    public RawImage ShotgunTxt;
    public RawImage TntTxt;
    public RawImage MinMedTxt;
    public RawImage MediumMedTxt;
    public RawImage BigMedTxt;
   

    public int Panel1Lvl = 0;
    public int Panel2Lvl = 0;
    public int Panel3Lvl = 0;
    public int Panel4Lvl = 0;

    void Start()
    {
       
       
       
       
    }
    
    void Update()
    {

        ///PANEL ONE///

        if(Panel1Lvl == 1)
        {
            WhatToShow(1, 1);
        }
        else if (Panel1Lvl == 2)
        {

        }
        else if (Panel1Lvl == 3)
        {

        }
        
        ///PANEL TWO///

        if (Panel2Lvl == 1)
        {
            WhatToShow(2, 1);
        }
        else if (Panel2Lvl == 2)
        {
            WhatToShow(2, 2);
        }
        else if (Panel2Lvl == 3)
        {
            WhatToShow(2, 3);
        }

        ///PANEL THREE///

        if (Panel3Lvl == 1)
        {
            WhatToShow(3, 1);
        }
        else if (Panel3Lvl == 2)
        {

        }
        else if (Panel3Lvl == 3)
        {

        }

        ///PANEL FOUR///

        if (Panel4Lvl == 1)
        {
            WhatToShow(4, 1);
        }
        else if (Panel4Lvl == 2)
        {
            WhatToShow(4, 2);
        }
        else if (Panel4Lvl == 3)
        {
            WhatToShow(4, 3);
        }





    }

    private void WhatToShow(int PanelNr, int PanelLvl)
    {

        ////////////////////P A N E L   O N E //////////////////////

        if (PanelNr == 1)
        {

            ///DAGGER///

            if (PanelLvl == 1)
            {
                DaggerTxt.color = new Vector4(DaggerTxt.color.r, DaggerTxt.color.g, DaggerTxt.color.b, 255);
            } else DaggerTxt.color = new Vector4(DaggerTxt.color.r, DaggerTxt.color.g, DaggerTxt.color.b, 0);
        }

        ////////////////////P A N E L   T W O //////////////////////

        else if (PanelNr == 2)
        {

            ///PISTOL///

            if (PanelLvl == 1)
            {
                PistolTxt.color = new Vector4(PistolTxt.color.r, PistolTxt.color.g, PistolTxt.color.b, 255);
            }
            else PistolTxt.color = new Vector4(PistolTxt.color.r, PistolTxt.color.g, PistolTxt.color.b, 0);

            ///SNIPER///

            if (PanelLvl == 2)
            {
                SniperTxt.color = new Vector4(SniperTxt.color.r, SniperTxt.color.g, SniperTxt.color.b, 255);
            }
            else SniperTxt.color = new Vector4(SniperTxt.color.r, SniperTxt.color.g, SniperTxt.color.b, 0);

            ///SHOTGUN///

            if (PanelLvl == 3)
            {
                ShotgunTxt.color = new Vector4(ShotgunTxt.color.r, ShotgunTxt.color.g, ShotgunTxt.color.b, 255);
            }
            else ShotgunTxt.color = new Vector4(ShotgunTxt.color.r, ShotgunTxt.color.g, ShotgunTxt.color.b, 0);
        }

        ////////////////////P A N E L   T H R E E //////////////////////


        else if (PanelNr == 3)
        {

            ///TNT///

            if (PanelLvl == 1)
            {
                TntTxt.color = new Vector4(TntTxt.color.r, TntTxt.color.g, TntTxt.color.b, 255);
            }
            else TntTxt.color = new Vector4(TntTxt.color.r, TntTxt.color.g, TntTxt.color.b, 0);
        }

        ////////////////////P A N E L   F O U R //////////////////////


        else if (PanelNr == 4)
        {

            ///MINMED///

            if (PanelLvl == 1)
            {
                MinMedTxt.color = new Vector4(MinMedTxt.color.r, MinMedTxt.color.g, MinMedTxt.color.b, 255);
            }
            else MinMedTxt.color = new Vector4(MinMedTxt.color.r, MinMedTxt.color.g, MinMedTxt.color.b, 0);

            ///MEDIUMMED///

            if (PanelLvl == 2)
            {
                MediumMedTxt.color = new Vector4(MediumMedTxt.color.r, MediumMedTxt.color.g, MediumMedTxt.color.b, 255);
            }
            else MediumMedTxt.color = new Vector4(MediumMedTxt.color.r, MediumMedTxt.color.g, MediumMedTxt.color.b, 0);

            ///BIGMED///

            if (PanelLvl == 3)
            {
                BigMedTxt.color = new Vector4(BigMedTxt.color.r, BigMedTxt.color.g, BigMedTxt.color.b, 255);
            }
            else BigMedTxt.color = new Vector4(BigMedTxt.color.r, BigMedTxt.color.g, BigMedTxt.color.b, 0);
        }




    }

}
