/*
 * Filename: StarterWeapon.cs
 * Developer: Oscar Michua-Zarate
 * Purpose: This file standardizes how specidic weapons will work.
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

    // Start is called before the first frame update
    void Start()
    {
        UpdateSpeed(10f);
        UpdateDamage(5f);
        UpdateRange(5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
