/*
 * Filename: CultistWeapon.cs
 * Developer: Oscar Michua-Zarate
 * Purpose: This file standardizes how this specific weapon will work.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

/*
 * Summary: Updates the stats for the CultistWeapon
 * Member Variables:
 * None
 */
public class CultistWeapon : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        UpdateSpeed(120f);
        UpdateDamage(1f);
        UpdateRange(0f);
    }
}
