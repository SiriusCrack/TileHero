/*
 * Filename: GoblinWeapon.cs
 * Developer: Oscar Michua-Zarate
 * Purpose: This file standardizes how this specific weapon will work.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

/*
 * Summary: Updates the stats for the GoblinWeapon
 * Member Variables:
 * None
 */
public class GoblinWeapon : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        UpdateSpeed(70f);
        UpdateDamage(2f);
        UpdateRange(0f);
    }
}
