using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    public int atk_speed;

    [SerializeField]
    public int atk_damage;

    [SerializeField]
    public int range;

    public Effect effect = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Useweapon(NPC target)
    {
    //    target.health -= damage;
    //    if(effect != null)
    //    {
    //        applyEffect(target)
    //    }
    }

    public void applyEffect(Effect effectType, NPC target)
    {
        
    }


}
