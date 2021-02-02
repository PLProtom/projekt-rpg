using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject panelInventory;
    [SerializeField] GameObject panelMenu;
    [SerializeField] Slider hpBar;
    [SerializeField] Slider manaBar;

    void Start()
    {
        panelInventory.SetActive(false);
        panelMenu.SetActive(false);

        hpBar.value = hpBar.maxValue;
        manaBar.value = manaBar.maxValue;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) panelInventory.SetActive(true);
        if (Input.GetKeyUp(KeyCode.B)) panelInventory.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Escape)) panelMenu.SetActive(true);
    }

    public void Resume()
    {
        panelMenu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
