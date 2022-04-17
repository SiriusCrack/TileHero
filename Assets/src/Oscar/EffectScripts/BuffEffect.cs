using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BuffEffect : MonoBehaviour
{
    public int EffectType = 3;

    public float EffectFunction(float strength, float npcHealth)
    {
        float health;
        health = npcHealth;
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

    public IEnumerator sleep(){
        yield return new WaitForSeconds(5);
    }

}

