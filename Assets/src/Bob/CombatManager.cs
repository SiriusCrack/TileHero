using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    int i;
    int enemiesRemaining;

    public Hero hero;

    //enemies array stores all the enemies the hero encounters
    public GameObject[] enemies;

    //the inactiveEnemy is a dummy enemy for when the enemies array is empty to avoid null reference errors
    //public GameObject inactiveEnemy;

    //currentEnemy moves whenever an enemy dies, and if there are no enemies in the
    //array it will update when an enemy is encountered, newEnemy is used when adding
    //new enemies encountered by the hero
    int currentEnemy = 0;
    //int newEnemy = 1;

    //used to judge when combat starts
    //float heroPos; <-Prolly unneeded
    //float enemyPos; <- Prolly unneeded

    int listLength;

    //tells if the hero is currently in combat
    bool inCombat;

    AttackCommand attack;

    // Start is called before the first frame update
    void Start()
    {
        //inactiveEnemy.gameObject.SetActive(false);
        //enemies[0] = inactiveEnemy;
        //heroPos = hero.transform.localPosition.y;
        inCombat = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets hero's and current enemy's position every frame
        //heroPos = hero.transform.localPosition.x;                         <-Prolly unneeded
        //enemyPos = enemies[currentEnemy].transform.localPosition.x;

        //This code will run when the hero encounters an enemy
        if (hero.collectEnemy == true)
        {
            collectEnemy();
        }

        //Combat code
        if (inCombat == true)
        {
            //If an enemy's healh drops to zero, remove them from the game
            for (i = 0; i < listLength; i++)
            {
                if (enemies[i].activeSelf)
                {
                    if (enemies[i].GetComponent<Enemy>().health == 0)
                    {
                        enemyDeath(i);
                    }
                }
            }
            //if the hero's health drops to zero, remove them from the game
            if (hero.health == 0)
            {
                Debug.Log("The hero fucking died lol");
                hero.gameObject.SetActive(false);
                inCombat = false;
            }
            //If the enemy's attack timer reaches their weaponspeed, have them attack the hero
            for (i = 0; i < listLength; i++)
            {
                if (enemies[i].activeSelf)
                {
                    Debug.Log(enemies[i].GetComponent<Enemy>().attackTimer);
                    if (enemies[i].GetComponent<Enemy>().attackTimer >= enemies[i].GetComponent<Enemy>().weapon.atkSpeed)
                    {
                        sendAttack(enemies[i].GetComponent<Enemy>(), hero);
                    }
                }
            }
            //If the hero's attack timer reaches their weaponspeed, have them attack the current enemy
            if (hero.attackTimer >= hero.weapon.atkSpeed)
            {
                sendAttack(hero, enemies[currentEnemy].GetComponent<Enemy>());
                hero.attackTimer = 0;
            }
        }

        //If combat has not been engaged and the hero encounters an enemy, start combat
        //if ((Mathf.Abs(heroPos - enemyPos) < 0.5) && (inCombat == false))
        //{
        //    enterCombat();
        //}
    }

    //Handles removing an enemy
    void enemyDeath(int enemyIndex)
    {
        //Prints that an enemy has died for debugging purposes
        //Debug.Log("death", enemies[currentEnemy]);
        //Debug.Log(enemies);

        //moves the enemy out of the game so the hero doesn't get stuck on them and sets them inactive
        enemies[enemyIndex].transform.Translate(1000, 1000, 0);
        enemies[enemyIndex].gameObject.SetActive(false);
        //enemies[enemyIndex] = null;

        //if there is an enemy queued, make them the next enemy, otherwise, the current enemy
        //is set to the inactiveEnemy to avoid null references and the hero is taken out of combat
        //if (enemies[currentEnemy + 1])
        //{
        //    currentEnemy++;
        //}
        //else
        enemiesRemaining = 0;
        for(i = 0; i < listLength; i++)
        {
            if(enemies[i].activeSelf)
            {
                enemiesRemaining += 1;
            }
        }

        if (enemiesRemaining == 0)
        {
            //enemies[currentEnemy] = inactiveEnemy;
            inCombat = false;
            hero.EndCombat();
        }
        else
        {
            currentEnemy++;
        }
    }

    //Creates and sends attacks to NPCs
    void sendAttack(NPC sender, NPC reciever)
    {
        //resets the attack timer
        sender.attackTimer = 0;
        //creates an attack command object based on the sender/reciever
        attack = new AttackCommand(sender, reciever, sender.weapon.atkDamage);
        //sends that to the target
        reciever.receiveAttack(attack);
        //destroys the object
        Destroy(attack);
    }

    //sets necessary values for variables upon combat start. kinda like the unity start() for combat
    void enterCombat()
    {
        //debugging message
        //Debug.Log("Combat begins");

        //set hero and combat manager variables to in combat
        //hero.StartCombat();
        inCombat = true;

        //reset hero an enemy attack timers
        hero.attackTimer = 0;
        for (i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].activeSelf)
            {
                enemies[i].GetComponent<Enemy>().attackTimer = 0;
            }
        }
        //enemies[currentEnemy].attackTimer = 0;
    }

    //Used to add enemies to the enemies array when a hero encounters them
    void collectEnemy()
    {
        Debug.Log("Entered Collection");
        //fills the earliest empty slot (newEnemy) with the enemy the hero encountered
        listLength = hero.enemies.Count;
        for (i = 0; i < listLength; i++)
        {
            Debug.Log("Iterating through array:");
            if (hero.enemies[i])
            {
                Debug.Log("Found valid enemy:");
                enemies[i] = hero.enemies[i];
            }
        }
        
        currentEnemy = 0;
        //enemies[newEnemy] = hero.currentEnemy;
        //update newEnemy to the next empty slot
        //newEnemy++;
        //reset the collection flag on the hero

        hero.collectEnemy = false;
        enterCombat();
        //if there is no enemy, have the hero begin fighting this enemy
        //if (enemies[currentEnemy] == inactiveEnemy)
        //{
        //    currentEnemy++;
        //}

        //debug printouts
        //Debug.Log("collection");
        //Debug.Log(enemies[currentEnemy]);
    }
}