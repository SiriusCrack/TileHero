/*
* Filename: StartButton.cs
* Developer: Kaleb Browning, kalebbrowning14@gmail.com, github.com/Brow8820
* Purpose: code to wait for any key to be pressed in demo mode
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Summary: class for waiting for button press
*/

public class WaitForKeyDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}
