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
    int count;

    // Start is called before the first frame update    
    void Start()
    {
        count = 0;
    }
    void Update()
    {   

       // print("test");
        //CountHits(10);
        //CountHits2();
    }

//only 1.05 - 1.2 for strength (5% health to 20% health taken away every 5 seconds)
//will change in the future, will be based on # of hits instead of time
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
        Debug.Log(count);
        if (count >= 3)
        {
            Debug.Log("super WOWWIE!");
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
