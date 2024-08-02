using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public float scrollvalue;
    public int activePanelNr;

    private CombatSystem combatSstm;
    private GameObject activePanel;

    private void Start()
    {
        combatSstm = FindObjectOfType<CombatSystem>();
        activePanel = panel1;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
         combatSstm.timeToSwitch = true;

            if (activePanel == panel1)
                activePanel = panel2;

            else if (activePanel == panel2)
                activePanel = panel3;

            else if (activePanel == panel3)
                activePanel = panel4;
            else if (activePanel == panel4)
                activePanel = panel1;
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            combatSstm.timeToSwitch = true;

            if (activePanel == panel4)
                activePanel = panel3;

            else if (activePanel == panel3)
                activePanel = panel2;

            else if (activePanel == panel2)
                activePanel = panel1;

            else if (activePanel == panel1)
                activePanel = panel4;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            activePanel = panel1;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            activePanel = panel2;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            activePanel = panel3;

        if (Input.GetKeyDown(KeyCode.Alpha4))
            activePanel = panel4;




        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);

        activePanel.SetActive(true);

        if (activePanel == panel1)
            activePanelNr = 1;
        if (activePanel == panel2)
            activePanelNr = 2;
        if (activePanel == panel3)
            activePanelNr = 3;
        if (activePanel == panel4)
            activePanelNr = 4;

    }
}
