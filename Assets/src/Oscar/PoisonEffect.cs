using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Effect;
using static NPC;

public class PoisonEffect : Effect
{
    public int EffectType = 2;
    NPC npc;
    Hero hero;
    Weapon weapon;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public float EffectFunction(float strength, float npcHealth)
{
    float health;
    health = npcHealth;
    health = (health - strength);
    EffectTime(5);
    health = (health - strength);
    EffectTime(5);
    health = (health - strength);
    return health;
}

public float CountEffect(float strength, float npcHealth)
{
    float health;
    health = npcHealth;
    health = EffectFunction(strength,npcHealth);
    return health;
}

}
