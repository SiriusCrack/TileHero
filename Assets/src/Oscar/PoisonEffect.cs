using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Effect;
using static NPC;
using System.Threading.Tasks;

public class PoisonEffect : Effect
{
    NPC npc;
    Hero hero;
    Weapon weapon;
    //int count;
    bool EffectApplied = false;

    // Start is called before the first frame update
    void Start()
    {
        //count = 0;
    }

    public float EffectFunction(float strength, float npcHealth)
    {
        EffectApplied = true;
        float health;
        health = npcHealth;
        if(EffectApplied == true){
            print("Effect used, health now" + health);
            health = (health - strength);
            print("Health after: " + health);
            StartCoroutine(sleep());
        }
        return health;
    }

    public float CountEffect(float strength, float npcHealth)
    {
        float health;
        health = npcHealth;
        health = EffectFunction(strength,npcHealth);
        return health;
    }

    public IEnumerator sleep(){
        yield return new WaitForSeconds(5);
    }

}
