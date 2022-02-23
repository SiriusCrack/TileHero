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
        Time.timeScale = 1;
    }

    void showShop()
    {
        shopMenu.enabled = true;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {   //Temporary, just for testing purposes
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                showShop();
            }
            else if (Time.timeScale == 0)
            {
                hideShop();
            }

        }
    }
}
