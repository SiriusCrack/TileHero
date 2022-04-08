using static NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : NPC
{
    // Start is called before the first frame update
    private bool messagePrinted;
    public Enemy thisEnemy;
    private enum enemyType {Goblin, Skeleton, Cultist, Dummy};
    [SerializeField]
    private enemyType type;

    void Start()
    {
        SetStats(type);
        thisEnemy = this;
        //messagePrinted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override IEnumerator Move(int heroLocation)
    {
        yield return new WaitForSeconds(1f);
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

    private void SetStats(enemyType localType)
    {
        switch(localType)
        {
            case enemyType.Goblin:
                setAtk(.5f);
                health = 50f;
                break;
            case enemyType.Skeleton:
                setAtk(1f);
                health = 15f;
                break;
            case enemyType.Cultist:
                setAtk(.75f);
                health = 13f;
                break;
            case enemyType.Dummy:
                setAtk(0f);
                health = 100f;
                break;                
            default:
                setAtk(1f);
                health = 10f;
                break;
        }
    }

    

   /* public int getAtk()
    {
        return base_atk;
    }*/


}

