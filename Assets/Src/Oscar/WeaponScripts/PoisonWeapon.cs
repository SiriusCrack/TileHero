/*
 * Filename: PoisonWeapon.cs
 * Developer: Oscar Michua-Zarate
 * Purpose: This file standardizes how this specific weapon will work.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

/*
 * Summary: Updates the stats for the PoisonWeapon
 * Member Variables:
 * None
 */
public class PoisonWeapon : Weapon
{
    //public int EffectType;
    // Start is called before the first frame update
    void Start()
    {
        UpdateSpeed(100f);
        UpdateDamage(9f);
        UpdateRange(5f);
    }

    public void ChangeEffectType(int change)
    {
        EffectType = change;
    }
}
