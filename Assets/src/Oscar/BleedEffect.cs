using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Effect;

public class BleedEffect : Effect
{
    public Effect effect;
    public NPC npc;
    
    // Start is called before the first frame update    
    void Start()
    {
        BleedEffectFunction(1.2f);
    }

//only 1.05 - 1.2 for strength (5% health to 20% health taken away every 5 seconds)
//will change in the future, will be based on # of hits instead of time
    public void BleedEffectFunction(float strength)
    {
        float health;
        
        while(npc.health > 0f)
        {
            Debug.Log("In 5: ");           
            effect.EffectTime(1);
            Debug.Log("In 4: ");           
            effect.EffectTime(1);
            Debug.Log("In 3: ");           
            effect.EffectTime(1);
            Debug.Log("In 2: ");           
            effect.EffectTime(1);
            Debug.Log("In 1: ");           
            effect.EffectTime(1);
            Debug.Log("Enemy Health = " + npc.health);
            health = npc.health;
            npc.health = health / strength;
            Debug.Log("New Enemy Health = " + npc.health);
            Debug.Log("Again: ");  
        }


    }

}
