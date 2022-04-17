using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

