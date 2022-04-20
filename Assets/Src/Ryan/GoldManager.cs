using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager
{

    public int Gold = 0;
    public GoldManager(int num)
    {
        Gold = num;
    }
    public void AddGold(int amount)
    {
        Gold = Gold + amount;
    }
    public void RemoveGold(int amount)
    {
        if(amount > Gold)
        {
            Debug.Log("Can't Spend money you dont have");
            //return false;
        }
        else
        {
            Gold = Gold - amount;
            Debug.Log("Removing " + amount + " Gold");
            //return true;
        }
    }


}
