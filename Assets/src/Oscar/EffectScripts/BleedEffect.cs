/*
 * Filename: BleedEffect.cs
 * Developer: Oscar Michua-Zarate
 * Purpose: This file will show how an effect effects a npc with bleed
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Creates a weapon class with blank inputs 
 *
 * Member Variables:
 * count - Int value to keep track how many hits has occured
 * EffectType - tells the game which effect id it is
 */
public class BleedEffect : MonoBehaviour
{
    public int EffectType = 1;
    BleedCultistsSpriteChange BleedCultistsSpriteChange;
    int count;

    // Start is called before the first frame update    
    void Start()
    {
        count = 0;
    }
/*
 * Summary: Changes the health of the npc when called
 *
 * Parameters:
 * strength - amount of damaged added on with attack
 * npcHealth - copies the amount of health the npc has
 * Returns:
 * None
 */   
    public float EffectFunction(float strength, float npcHealth)
    {
        float health;
        health = npcHealth;
        health = (health / strength);
        Debug.Log(health);
        return health;
    }

    public float CountHits(float strength, float npcHealth)
    {
        float health;
        health = npcHealth;
        count = count + 1;
        if (count >= 3)
        {
            health = EffectFunction(strength, npcHealth);
            count = 0;
            //BleedCultistsSpriteChange.ShowBleed();
        }
        return health;
    }

        public void CountHits2()
    {
        BleedCultistsSpriteChange.ShowBleed();
    }
}

