using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShopMenu : MonoBehaviour
{
    public GameObject total;
    public bool shopActive;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowShopForSeconds());
        Time.timeScale = 0;
    }

    public void showInterface()
    {
        total.SetActive(true);
        Time.timeScale = 0;
    }
    void hideInterface()
    {
        total.SetActive(false);
        Time.timeScale = 1;
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                showInterface();
            }
            else if (Time.timeScale == 0)
            {
                hideInterface();
            }

        }
    }

    private IEnumerator ShowShopForSeconds()
    {
        showInterface();
        yield return new WaitForSecondsRealtime(3);
        hideInterface();
    }
}

