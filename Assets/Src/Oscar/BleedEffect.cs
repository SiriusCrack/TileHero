using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Effect;
using static NPC;


public class BleedEffect : Effect
{
    public int EffectType = 1;
    NPC npc;
    Hero hero;
    Weapon weapon;
    BleedCultistsSpriteChange BleedCultistsSpriteChange;

    // Start is called before the first frame update    
    void Update()
    {   

       // print("test");
        //CountHits(10);
        //CountHits2();
    }

//only 1.05 - 1.2 for strength (5% health to 20% health taken away every 5 seconds)
//will change in the future, will be based on # of hits instead of time
    public void EffectFunction(float strength)
    {
        float health;
        health = npc.GetHealth();
        npc.UpdateHealth(health / strength);
        print(health);
    }

    public void CountHits(float strength)
    {
        int count = 0;
        if(hero.weapon.attackTimer >= weapon.atkSpeed){
            count = count + 1;
            print (count);
            if (count == 3)
            {
                EffectFunction(strength);
                //BleedCultistsSpriteChange.ShowBleed();
            }
        }
    }

        public void CountHits2()
    {
        BleedCultistsSpriteChange.ShowBleed();
    }
}
