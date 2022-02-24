using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopMenu : MonoBehaviour
{
    public MonoBehaviour shopMenua;
    public MonoBehaviour shopMenub;
    public MonoBehaviour shopMenuc;
    public MonoBehaviour inventoryMenua;
    public MonoBehaviour inventoryMenub;
    public MonoBehaviour inventoryMenuc;
    public MonoBehaviour equipMenua;
    public MonoBehaviour equipMenub;
    public MonoBehaviour equipMenuc;
    // Start is called before the first frame update
    void Start()
    {
        hideInterface();
        Time.timeScale = 1;
    }

    public void showInterface()
    {
        showShop();
        showInventory();
        showEquip();
    }
    void hideInterface() {
        hideShop();
        hideInventory();
        hideEquip();
    }

    void hideShop()
    {
        shopMenua.enabled = false;
        shopMenub.enabled = false;
        shopMenuc.enabled = false;
    }

    void showShop()
    {
        shopMenua.enabled = true;
        shopMenub.enabled = true;
        shopMenuc.enabled = true;
    }

    void hideInventory()
    {
        inventoryMenua.enabled = false;
        inventoryMenub.enabled = false;
        inventoryMenuc.enabled = false;
    }

    void showInventory()
    {
        inventoryMenua.enabled = true;
        inventoryMenub.enabled = true;
        inventoryMenuc.enabled = true;
    }


    void hideEquip()
    {
        equipMenua.enabled = false;
        equipMenub.enabled = false;
        equipMenuc.enabled = false;
    }

    void showEquip()
    {
        equipMenua.enabled = true;
        equipMenub.enabled = true;
        equipMenuc.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                showInterface();
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                hideInterface();
                Time.timeScale = 1;
            }

        }
    }
}
    
