using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PoisonEffect : MonoBehaviour
{

    bool EffectApplied = false;
    public int EffectType = 2;

    public float EffectFunction(float strength, float npcHealth)
    {
        EffectApplied = true;
        float health;
        health = npcHealth;
        if(EffectApplied == true){
            health = (health - strength);
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

