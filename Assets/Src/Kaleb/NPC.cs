/*
* Filename: NPC.cs
* Developer: Kaleb Browning, kalebbrowning14@gmail.com, github.com/Brow8820
* Purpose: An abstract NPC class that includes health, attack, position storage
*          and a virtual function for movement.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: an abstract class for NPCs within a game
*
* Member Variables:
*     health- A float that stores the current health of the NPC
*     baseAtk- A float the represents the attack of the npc
*     attackTimer- An int that represents the time between attacks
*     weapon- A custom Weapon class variable that stores the NPCs weapon
*     position- A Vector2 that stores the NPCs coordinates
*/

public abstract class NPC : MonoBehaviour
{
    [SerializeField]
    public float health;

    [SerializeField]
    float baseAtk;

    public int attackTimer = 0;
    public Weapon weapon;

    public BleedEffect bleedEffect;

    public PoisonEffect poisonEffect;

    public CombatAI combatAI;

    int funnyNumber;

    Vector2 position; 
    // Start is called before the first frame update
    void Start()
    {
        funnyNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void receiveAttack(AttackCommand attack)
    {
        if (funnyNumber != 1)
        {
            combatAI.setMaxHealth(health);
            funnyNumber = 1;
        }
        if (attack.effect == 1)
        {
            //2 = strength, divides health by 2
            health = bleedEffect.CountHits(2, health);
        }
        if(attack.effect == 2)
        {
            //5 = strength, subtracts 5 health from npc
            health = poisonEffect.CountEffect(5, health);
        }

        health -= attack.damage;
        if (health < 0)
        {
            health = 0;
        }
        combatAI.updateSlider(health);
        Destroy(attack);
    }

    public abstract IEnumerator Move(int goalCoords);
    public float getAtk()
    {
        return baseAtk;
    }

    public void setAtk(float atk)
    {
        baseAtk = atk;
    }
    public void debuff(string type, float amount)
    {
        if(type == "atk")
        {
            if(amount >= baseAtk)
            {
                baseAtk = 1f;
                return;
            }else{
                baseAtk -= amount;
            }
        }
    }

    public float GetHealth()
    {
        return health;
    }
    
    public void UpdateHealth(float newHealth)
    {
        health = newHealth;
    }
}
