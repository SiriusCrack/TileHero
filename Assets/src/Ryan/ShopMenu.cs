using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopMenu : MonoBehaviour
{
    public MonoBehaviour shopMenu;
    // Start is called before the first frame update
    void Start()
    {
        hideShop();
        Time.timeScale = 1;
    }

    void hideShop()
    {
        shopMenu.enabled = false;
        
    }

    void showShop()
    {
        shopMenu.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                showShop();
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                hideShop();
                Time.timeScale = 1;
            }

        }
    }
}
    

