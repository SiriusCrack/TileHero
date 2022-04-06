using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitProgram()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(15);
        //Debug.LogError("-------------------Transition Here---------------------------------");
        SceneManager.LoadScene("Demo");
    }
}
