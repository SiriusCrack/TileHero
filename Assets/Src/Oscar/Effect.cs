using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Effect : MonoBehaviour
{

    int health_scalar;
    int health_multiplier;
    int damage_scalar;
    int damage_multiplier;
    float effectTime;
    public float strength;


    public void EffectFunction()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void health_effect()
    {
        
    }

    public void damage_effect()
    {
        
    }
//length ends up being in seconds
    public void EffectTime(int length)
    {
        length = length * 1000;
        Thread.Sleep(length);
    }

}
