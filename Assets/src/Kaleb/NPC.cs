using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    [SerializeField]
    public int health;

    [SerializeField]
    float base_atk;

    public int attackTimer = 0;
    public Weapon weapon;

    Vector2 position; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void receiveAttack(AttackCommand attack)
    {
        health -= attack.damage;
        if (health < 0)
        {
            health = 0;
        }
    }

    public abstract void Move(int goalCoords);
    public float getAtk()
    {
        return base_atk;
    }

    public void setAtk(float atk)
    {
        base_atk = atk;
    }
    public void debuff(string type, float amount)
    {
        if(type == "atk")
        {
            if(amount >= base_atk)
            {
                base_atk = 1f;
                return;
            }else{
                base_atk -= amount;
            }
        }
    }
}
