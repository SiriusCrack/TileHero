/*
 * Filename: BuffEffect.cs
 * Developer: Oscar Michua-Zarate
 * Purpose: This file standardizes effects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

/*
 * Summary: Creates effect 
 *
 * Member Variables:
 * None
 */
public class Effect : MonoBehaviour
{

/*
 * Summary: Should overwrite a effect function
 *
 * Parameters:
 * None
 * Returns:
 * None
 */   
    public virtual void EffectFunction()
    {

    }

/*
 * Summary: Allow wait to occur in code
 *
 * Parameters:
 * length - a variable to get length
 * Returns:
 * None 
 */   
    //length ends up being in seconds
    public void EffectTime(int length)
    {
        length = length * 1000;
        Thread.Sleep(length);
    }
}