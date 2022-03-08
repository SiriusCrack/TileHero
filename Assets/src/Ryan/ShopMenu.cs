using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopMenu : MonoBehaviour
{
    public GameObject total;

    // Start is called before the first frame update
    void Start()
    {
        showInterface();
        Time.timeScale = 0;
    }

    public void showInterface()
    {
        total.SetActive(true);
    }
    void hideInterface() 
    {
        total.SetActive(false);
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
    
