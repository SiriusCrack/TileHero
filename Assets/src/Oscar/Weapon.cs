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

    //public void Useweapon(npc target)
    //{
    //    target.health -= damage;
    //    if(effect != null)
    //    {
    //        applyEffect(target)
    //    }
    //}

    //public void applyEffect(Effect effectType, Enemy target)
    //{
        
    //}

    public void weaponSpeed(int speed)
    {
        if(speed <= 0){
            speed = 5;
            return;
        }
        atk_speed = speed;
    }

}
