using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopMenu : MonoBehaviour
{
    public MonoBehaviour shopMenu0;
    public MonoBehaviour shopeMenu1;
    public MonoBehaviour shopoMenu2;
    // Start is called before the first frame update
    void Start()
    {
        hideShop();
        Time.timeScale = 1;
    }

    void hideShop()
    {
        shopMenu0.enabled = false;
        shopeMenu1.enabled = false;
        shopoMenu2.enabled = false;
    }

    void showShop()
    {
        shopMenu0.enabled = true;
        shopeMenu1.enabled = true;
        shopoMenu2.enabled = true;
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
    
