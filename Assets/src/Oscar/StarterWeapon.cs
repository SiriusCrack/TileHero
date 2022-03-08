using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;



public class StarterWeapon : Weapon
{

    // Start is called before the first frame update
    void Start()
    {
        atk_damage = 5;
        atk_speed = 10;
        range = 5;
        effect = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }





}
