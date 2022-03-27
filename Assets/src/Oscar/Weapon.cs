/*
 * Filename: Weapon.cs
 * Developer: Oscar Michua-Zarate
 * Purpose: This file standardizes how weapons will work.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Creates a weapon class with blank inputs 
 *
 * Member Variables:
 * atkSpeed - Int value of attack speed
 * atkDamage - Int value of attack damage
 * atkRange - Int value of attack range
 * effect - Place holder for a effect type script
 */
public class Weapon : MonoBehaviour
{
    [SerializeField]
    public float atkSpeed;

    [SerializeField]
    public float atkDamage;

    [SerializeField]
    public float atkRange;

    public Effect effect = null;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void applyEffect(Effect effectType, Enemy target)
    //{
        
    //}


/*
 * Summary: Updates the weapon damage to match the given input
 *
 * Parameters:
 * damage - inputs a float to give damage value
 *
 * Returns:
 * None
 */   
    public void UpdateDamage(float damage)
    {
        atkDamage = damage;
    }

/*
 * Summary: Updates the weapon speed to match the given input
 *
 * Parameters:
 * speed - inputs a float to give speed value
 *
 * Returns:
 * None
 */   
    public void UpdateSpeed(float speed)
    {
        atkSpeed = speed;
    }

/*
 * Summary: Updates the weapon range to match the given input
 *
 * Parameters:
 * range - inputs a float to give range value
 *
 * Returns:
 * None
 */   
    public void UpdateRange(float range)
    {
        atkRange = range;
    }

/*
 * Summary: Made for boundary test to check weapon speed
 *
 * Parameters:
 * speed - inputs a int to check if atkSpeed is working properly
 *
 * Returns:
 * 
 */ 
    public void WeaponSpeed(int speed)
    {
        if(speed <= 0){
            speed = 5;
            return;
        }
        atkSpeed = speed;
    }

}
