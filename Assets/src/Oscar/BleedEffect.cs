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
        CountAttacks();
        //BleedEffectFunction(1.2f);
    }

//only 1.05 - 1.2 for strength (5% health to 20% health taken away every 5 seconds)
//will change in the future, will be based on # of hits instead of time
    public void BleedEffectFunction(float strength)
    {
        float health;
        health = npc.health;
        npc.health = health / strength;
    }

    public void CountAttacks()
    {
        int counter = 0;
        if (weapon.attackTimer >= weapon.atkSpeed)
        {
            counter = counter + 1;
            if(counter == 5)
            {
                counter = 0;
                //BleedEffectFunction();
            }
        }
    }
}
