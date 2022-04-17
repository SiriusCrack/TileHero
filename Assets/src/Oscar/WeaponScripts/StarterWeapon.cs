/*
 * Filename: StarterWeapon.cs
 * Developer: Oscar Michua-Zarate
 * Purpose: This file standardizes how this specific weapon will work.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

/*
 * Summary: Updates the stats for the StarterWeapon
 * Member Variables:
 * None
 */
public class StarterWeapon : Weapon
{
    //public int EffectType;
    // Start is called before the first frame update
    void Start()
    {
        UpdateSpeed(100f);
        UpdateDamage(10f);
        UpdateRange(5f);
    }

    public void ChangeEffectType(int change)
    {
        EffectType = change;
    }
}
