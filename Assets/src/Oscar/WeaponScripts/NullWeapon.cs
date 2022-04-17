/*
 * Filename: NullWeapon.cs
 * Developer: Oscar Michua-Zarate
 * Purpose: This file will give null if no weapon is added to an enemy
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

/*
 * Summary: Updates the stats for the NullWeapon
 * Member Variables:
 * None
 */
public class NullWeapon : Weapon
{
    // public int EffectType;
    // Start is called before the first frame update
    void Start()
    {
        //null pattern
        UpdateSpeed(0f);
        UpdateDamage(0f);
        UpdateRange(0f);
    }

    public void ChangeEffectType(int change)
    {
        EffectType = change;
    }
}
