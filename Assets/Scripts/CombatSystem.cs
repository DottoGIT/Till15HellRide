using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public GameObject currentWeapon;
    private GameObject oldCurrentWeapon;
    private Equipment eq;
    private LayingWeapons lW;
    private MedicineScript MedScript;
    public bool timeToSwitch = true;
    public int MinMedHeal;
    public int MidMedHeal;
    public int BigMedHeal;

    public GameObject bareHands;
    public GameObject Dagger;
    public GameObject Pistol;
    public GameObject Sniper;
    public GameObject Shotgun;
    public GameObject TNT;
    public GameObject Medpack;


    void Start()
    {

        MedScript = Medpack.GetComponent<MedicineScript>();
        var myWeapon = Instantiate(currentWeapon, gameObject.transform.position, gameObject.transform.rotation);
        myWeapon.transform.parent = gameObject.transform;
        timeToSwitch = false;
        eq = FindObjectOfType<Equipment>();
        lW = FindObjectOfType<LayingWeapons>();
    }


    void Update()
    {
        oldCurrentWeapon = currentWeapon;


        checkWhatIsCurrentWeapon();
        spawningWeapons();

        bareHandsCombat();
        Panel1Weapons();
        Panel2Weapons();
        Panel3Weapons();
        Panel4Weapons();


    }


    public void checkWhatIsCurrentWeapon()
    {

        /////////////PANEL ONE//////////////

        if(eq.activePanelNr == 1)
        {
            if (lW.Panel1Lvl == 0)
                currentWeapon = bareHands;

            if (lW.Panel1Lvl == 1)
                currentWeapon = Dagger;
        }

        /////////////PANEL TWO//////////////

        if (eq.activePanelNr == 2)
        {
            if (lW.Panel2Lvl == 0)
                currentWeapon = bareHands;

            if (lW.Panel2Lvl == 1)
                currentWeapon = Pistol;

            if (lW.Panel2Lvl == 2)
                currentWeapon = Sniper;

            if (lW.Panel2Lvl == 3)
                currentWeapon = Shotgun;
        }

        /////////////PANEL THREE//////////////

        if (eq.activePanelNr == 3)
        {
            if (lW.Panel3Lvl == 0)
                currentWeapon = bareHands;

            if (lW.Panel3Lvl == 1)
                currentWeapon = TNT;
        }

        /////////////PANEL FOUR//////////////

        if (eq.activePanelNr == 4)
        {

            if (lW.Panel4Lvl == 0)
                currentWeapon = bareHands;


            if (lW.Panel4Lvl !=0)
            {
                currentWeapon = Medpack;
            }

        }


    }
    private void spawningWeapons()
    {

        if (timeToSwitch && currentWeapon != oldCurrentWeapon)
        {
            var myWeapon = Instantiate(currentWeapon, gameObject.transform.position, gameObject.transform.rotation);
            myWeapon.transform.parent = gameObject.transform;
            timeToSwitch = false;
        }
    }
    private void Panel1Weapons()
    {
        if (currentWeapon == Dagger)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                var daggerScrpt = FindObjectOfType<DaggerScript>();
                daggerScrpt.StartStabAnimation();
            }
        }
    }
    private void Panel2Weapons()
    {
        if (currentWeapon == Pistol)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                var Pistol = FindObjectOfType<PistolController>();
                Pistol.StartShotAnim();
            }
        }

        else if (currentWeapon == Sniper)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                var SniperHere = FindObjectOfType<SniperController>();
                 SniperHere.StartShotAnim();
            }
        }

        else if (currentWeapon == Shotgun)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                var ShotgunHere = FindObjectOfType<ShotgunController>();
                ShotgunHere.StartShotAnim();
            }
        }
    }
    private void Panel3Weapons()
    {
        if (currentWeapon == TNT)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                var TnT = FindObjectOfType<TnTController>();
                TnT.StartPutAnim();
            }
        }
    }
    private void Panel4Weapons()
    {


        if (currentWeapon == Medpack)
        {
            var SelfHealSript = FindObjectOfType<SelfHealWeapon>();
            var PlrHp = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<HealthSystem>();

            if (lW.Panel4Lvl == 1 && Input.GetKey(KeyCode.Mouse0) && PlrHp.healthNow < PlrHp.health)
            {
                SelfHealSript.SelfHeal(MinMedHeal);
                lW.Panel4Lvl = 0;
                currentWeapon = bareHands;
                timeToSwitch = true;
                spawningWeapons();

            }
            if (lW.Panel4Lvl == 2 && Input.GetKey(KeyCode.Mouse0) && PlrHp.healthNow < PlrHp.health)
            {
                SelfHealSript.SelfHeal(MidMedHeal);
                lW.Panel4Lvl = 0;
                currentWeapon = bareHands;
                timeToSwitch = true;
                spawningWeapons();



            }
            if (lW.Panel4Lvl == 3 && Input.GetKey(KeyCode.Mouse0) && PlrHp.healthNow < PlrHp.health)
            {
                SelfHealSript.SelfHeal(BigMedHeal);
                lW.Panel4Lvl = 0;
                currentWeapon = bareHands;
                timeToSwitch = true;
                spawningWeapons();



            }

        }


    }
    private void bareHandsCombat()
    {

        if (currentWeapon == bareHands)
        {
            var HndContr = FindObjectOfType<HandsController>();

            if (Input.GetKey(KeyCode.Mouse0))
            {
                HndContr.RightPunch();
            }
            else if (Input.GetKey(KeyCode.Mouse1))
            {
                HndContr.LeftPunch();
            }

        }

    }
}
