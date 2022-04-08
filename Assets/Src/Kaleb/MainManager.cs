using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public bool drbcEnable;

    public float playerHealth = 120;
    public float playerAtk = 0;
    public int gold = 0;
    public Weapon playerWeapon;
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
    }

    void Update()
    {
        if(drbcEnable)
        {
            playerHealth = 999999999;
        }
    }

    


}
