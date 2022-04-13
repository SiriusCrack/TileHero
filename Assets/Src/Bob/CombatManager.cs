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

    //currentEnemy specifies which enemy in the array the hero
    //will attack
    int currentEnemy = 0;

    //Specifies how many enemies are in the room when combat
    //starts, allowing for loops to check all enemies
    int listLength;

    //tells if the hero is currently in combat
    bool inCombat;

    public AttackCommand attackCommand;

    //Used to create other attack commands
    AttackCommand attack;

    private AudioSource enemyHit;
    private AudioSource heroHit;

    // Start is called before the first frame update
    void Start()
    {
        inCombat = false;
        enemyHit = gameObject.AddComponent<AudioSource>();
        heroHit = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //This code will run when the hero enters a new room to get the enemies in the room
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
                hero.gameObject.SetActive(false);
                inCombat = false;
            }
            //If the enemy's attack timer reaches their weaponspeed, have them attack the hero
            for (i = 0; i < listLength; i++)
            {
                if (enemies[i].activeSelf)
                {
                    //Debug.Log(enemies[i].GetComponent<Enemy>().attackTimer);
                    if (enemies[i].GetComponent<Enemy>().attackTimer >= enemies[i].GetComponent<Enemy>().weapon.atkSpeed)
                    {
                        enemyHit.Play();
                        sendAttack(enemies[i].GetComponent<Enemy>(), hero);
                    }
                }
            }
            //If the hero's attack timer reaches their weaponspeed, have them attack the current enemy
            if (hero.attackTimer >= hero.weapon.atkSpeed)
            {
                heroHit.Play();
                sendAttack(hero, enemies[currentEnemy].GetComponent<Enemy>());
                hero.attackTimer = 0;
            }
        }
    }

    //Handles removing an enemy
    void enemyDeath(int enemyIndex)
    {

        //moves the enemy out of the game so the hero doesn't get stuck on them and sets them inactive
        enemies[enemyIndex].transform.Translate(1000, 1000, 0);
        enemies[enemyIndex].gameObject.SetActive(false);

        //resets the enemies remaining count each time an enemy dies then check all enemies again
        enemiesRemaining = 0;
        for(i = 0; i < listLength; i++)
        {
            if(enemies[i].activeSelf)
            {
                enemiesRemaining += 1;
            }
        }

        //if all enemies have died, exit combat. Else, move to the next target
        if (enemiesRemaining == 0)
        {
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
        attack = Instantiate(attackCommand);
        attack.setAttributes(sender, reciever, sender.weapon.atkDamage, sender.weapon.EffectType);
        //sends that to the target
        reciever.receiveAttack(attack);
        //destroys the object
        Destroy(attack);
    }

    //sets necessary values for variables upon combat start. kinda like the unity start() for combat
    void enterCombat()
    {
        //allows combat manager to process combat
        inCombat = true;

        //reset hero and enemy attack timers since they run constantly out of combat
        hero.attackTimer = 0;
        //for (i = 0; i < enemies.Length; i++)
        //{
        //    if (enemies[i].activeSelf)
        //    {
        //        Debug.Log("Enemies Index:");
        //        Debug.Log(i);
        //        enemies[i].GetComponent<Enemy>().attackTimer = 0;
        //    }
        //}
    }

    //Used to add enemies to the enemies array when a hero encounters them
    void collectEnemy()
    {
        //Gets the length of the list of enemies in the room
        if (hero.enemies.Count != 0)
        {
            listLength = hero.enemies.Count;
            //Adds the enemies into the enemies array on combat manager
            for (i = 0; i < listLength; i++)
            {
                if (hero.enemies[i])
                {
                    enemies[i] = hero.enemies[i];
                }
            }

            //sets the current enemy to the first one
            currentEnemy = 0;
            //resets the collectionflag
            hero.collectEnemy = false;
            //begins combat
            enterCombat();
        }
        else
        {
            hero.EndCombat();
            hero.collectEnemy = false;
        }
    }
}