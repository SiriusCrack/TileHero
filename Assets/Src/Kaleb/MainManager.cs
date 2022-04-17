/*
* Filename: MainManager.cs
* Developer: Kaleb Browning, kalebbrowning14@gmail.com, github.com/Brow8820
* Purpose: A static class that stores and transitions our levels in game.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Summary: A static class for data storage
*
* Member Variables:
*     playerHealth- the health of the player between levels
*     playerAtk- the base atk of the player
*     gold- the amount of gold earned this session
*     playerWeapon- the weapon that player currently has equipped between levels
*     nextLevel- an int to go through the levels
*/

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public bool drbcEnable;

    public float playerHealth = 120;
    public float playerAtk = 0;
    public int gold = 0;
    public Weapon playerWeapon;
    public int nextLevel;
    //public inventory
    
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        playerHealth = 120;
        playerAtk = 0;
        gold = 0;
        nextLevel = 1;
    }

    void Update()
    {
        if(drbcEnable)
        {
            playerHealth = 999999999;
        }
    }

    public void LoadNextLevel()
    {
        if(nextLevel == 1)
        {
            nextLevel++;
            SceneManager.LoadScene("Level1");
            return;
        }
        if(nextLevel == 2)
        {
            nextLevel++;
            SceneManager.LoadScene("Level2");
            return;
        }
    }
    


}
