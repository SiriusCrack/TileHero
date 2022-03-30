using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Effect;
using static NPC;


public class BleedEffect : Effect
{
    NPC npc;
    Hero hero;
    Weapon weapon;

    // Start is called before the first frame update    
    void Update()
    {
        EffectFunction(strength);
    }

//only 1.05 - 1.2 for strength (5% health to 20% health taken away every 5 seconds)
//will change in the future, will be based on # of hits instead of time
    public void EffectFunction(float strength)
    {
        float health;
        health = npc.health;
        npc.health = health / strength;
    }
}
