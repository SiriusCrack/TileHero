using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NPC;

public class Enemy : NPC
{
    // Start is called before the first frame update
    private bool messagePrinted;
    public Enemy thisEnemy;
    void Start()
    {
        thisEnemy = this;
        //messagePrinted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Move(int heroLocation)
    {
        
    }

    void FixedUpdate()
    {
        attackTimer += 1;
    }
    public void takeDamage(int dmg)
    {
        if(dmg > health)
        {
            health = 0;
            return;
        }
        health -= dmg;
    }

    

   /* public int getAtk()
    {
        return base_atk;
    }

    public void setAtk(int atk)
    {
        base_atk = atk;
    }*/

}

