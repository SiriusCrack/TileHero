using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Effect : MonoBehaviour
{
    float effectTime;
    public float strength;

    public virtual void EffectFunction()
    {

    }

    //length ends up being in seconds
    public void EffectTime(int length)
    {
        length = length * 1000;
        Thread.Sleep(length);
    }
}