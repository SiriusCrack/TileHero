/*
 * Filename: BuffEffect.cs
 * Developer: Oscar Michua-Zarate
 * Purpose: This file will show how an effect effects a npc with the buff effect
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/*
 * Summary: Creates a Buff effect
 *
 * Member Variables:
 * EffectType - gives a effect id variable
 */
public class BuffEffect : MonoBehaviour
{
    public int EffectType = 3;

/*
 * Summary: Changes the health of the npc when called
 *
 * Parameters:
 * strength - amount of damaged added on with attack
 * npcHealth - copies the amount of health the npc has
 * Returns:
 * health - health of the npc
 */   
    public float EffectFunction(float strength, float npcHealth)
    {
        float health;
        health = npcHealth;
        health = (health - strength);
        return health;
    }

/*
 * Summary: Changes the health of the npc when called
 *
 * Parameters:
 * strength - amount of damaged added on with attack
 * npcHealth - copies the amount of health the npc has
 * Returns:
 * health - health of the npc
 */   
    public float CountEffect(float strength, float npcHealth)
    {
        float health;
        health = npcHealth;
        health = EffectFunction(strength,npcHealth);
        return health;
    }

/*
 * Summary: Makes a wait gap in time for the script
 *
 * Parameters:
 * None
 * Returns:
 * None
 */   
    public IEnumerator sleep(){
        yield return new WaitForSeconds(5);
    }

}


