/*
* Filename:Enemy.cs
* Developer: Kaleb Browning, kalebbrowning14@gmail.com, github.com/Brow8820
* Purpose: A class for the enemies of the game
*/
using static NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Summary: an abstract class for NPCs within a game
*
* Member Variables:
*     messagePrinted- debug for combat
*     thisEnemy- a self referential var for the combat manager
*     enemyType type- an enum that determines the type of the enemy
*/

public class Enemy : NPC
{
    // Start is called before the first frame update
    private bool messagePrinted;
    public Enemy thisEnemy;
    int maxHealthInitialized;
    private enum enemyType {Goblin, Skeleton, Cultist, Dummy};
    [SerializeField]
    private enemyType type;

    void Start()
    {
        maxHealthInitialized = 0;
        SetStats(type);
        thisEnemy = this;
        //messagePrinted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    * Summary: not implemented
    *
    * Parameters: heroLocation- the location of the hero
    *
    * Returns
    */
    public override IEnumerator Move(int heroLocation)
    {
        yield return new WaitForSeconds(1f);
    }

    void FixedUpdate()
    {
        combatAI.UpdateLocation(transform.position);
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

    /*
    * Summary: sets stats based on enemy stats
    *
    * Parameters: localType- the enemy type 
    *
    * Returns
    */
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

    




}

