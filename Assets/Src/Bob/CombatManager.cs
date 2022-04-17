/*
 * Filename:    CombatManager.cs
 * Developer:   Robert Walko
 * Purpose:     Contains the combat manager object
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Mediator which processes all combat in the game. It
 * gets the enemies from the hero and keeps track of if they're
 * alive, if they need to attack, and who the hero is targeting.
 * It also sends attacks between the hero and the enemies.
 * 
 * Member Variables:
 * i:                   iterator variable used in loops.
 * enemiesRemaining:    The amount of enemies still alive. this
 *                      is used in the EnemyDeath function to
 *                      determine if combat should end.
 * hero:                The hero NPC.
 * enemies:             an array which contains the enemies in 
 *                      the tile the hero is currently in. This
 *                      is referenced in most function in the CM
 * currentEnemy:        The index of the enemy the hero is targeting
 * listLength:          The number of enemies in the room at combat
 *                      start, which allows for loops to check through
 *                      all enemies
 * inCombat:            Tracks whether the hero is in combat at the moment
 * centerPosition:      Combat does not start until the hero stops moving.
 *                      when the hero stops, this vector3 is set, and the 
 *                      hero will return here when combat ends. This allows
 *                      the CM to move the hero all over the room without
 *                      worrying about disrupting the movement script
 * attackCommand:       This is used as a model for the other commands. The
 *                      clones are the object attack, which is used to make
 *                      attacks.
 * attack:              the command that is sent to npcs
 * allAudio:            An audiosource object holding two clips, the two hit
 *                      sounds
 */
public class CombatManager : MonoBehaviour
{
    int i;

    public GameObject[] enemies;
    int currentEnemy = 0;
    int enemiesRemaining;
    int listLength;

    public Hero hero;
    bool inCombat;

    Vector3 centerPosition;

    public AttackCommand attackCommand;
    AttackCommand attack;

    public AudioSource[] allAudio;

    void Start()
    {
        inCombat = false;
        //this makes it so all audio sources attached to the object
        //fall into  one array. Without this, audiosources are all wonky
        allAudio = GetComponents<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {

        //This code will run when the hero enters a new room to get the enemies in the room
        if (hero.collectEnemy == true)
        {
            CollectEnemy();
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
                        EnemyDeath(i);
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
                    if (enemies[i].GetComponent<Enemy>().attackTimer >= enemies[i].GetComponent<Enemy>().weapon.atkSpeed)
                    {
                        allAudio[1].Play();
                        SendAttack(enemies[i].GetComponent<Enemy>(), hero);
                    }
                }
            }

            //If the hero's attack timer reaches their weaponspeed, have them attack the current enemy
            if (hero.attackTimer >= hero.weapon.atkSpeed)
            {
                allAudio[0].Play();
                SendAttack(hero, enemies[currentEnemy].GetComponent<Enemy>());
                hero.attackTimer = 0;
            }

        }
    }



    /*
     * Summary: Handles everything that occurs when an enemy dies. This incluides
     * setting the enemy inactive, ending combat if no enemies remain, and having the 
     * hero engage the next enemy if there are more
     * 
     * Parameters: 'enemyIndex' the index of the last enemy killed. Currently, that is
     * always going to be the currentEnemy variable since there are no AOE attacks :(
     * 
     * Returns:
     * Nothing
     */
    void EnemyDeath(int enemyIndex)
    {
        //moves the enemy out of the game so the hero doesn't get stuck on them and sets them inactive
        //leftover from the combat demo - No longer really necessary but I'm afraid to get rid of it now 
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
            hero.transform.position = centerPosition;
            hero.EndCombat();
        }
        else
        {
            currentEnemy++;
            //If the next enemy exists, have the next enemy and the hero's sprites will move to show who the current target is
            if (enemies[currentEnemy])
            {
                enemies[currentEnemy].GetComponent<Enemy>().transform.position =
                    enemies[currentEnemy].GetComponent<Enemy>().combatAI.EngageCombat(enemies[currentEnemy].GetComponent<Enemy>().transform.position);

                hero.transform.position = hero.combatAI.EngageCombat(enemies[currentEnemy].GetComponent<Enemy>().transform.position);
                
            }
        }
    }

    /*
    * Summary:      Sends an attack to an NPC, then calls the recieve function on the NPC.
    * 
    * Parameters:   Sender and reciever, the guy attacking and the guy getting hit
    * 
    * Returns:      Nothing
    */
    //Creates and sends attacks to NPCs
    void SendAttack(NPC sender, NPC reciever)
    {
        //resets the attack timer on the sender
        sender.attackTimer = 0;
        //creates an attack command object based on the sender/reciever
        attack = Instantiate(attackCommand);
        attack.SetAttributes(sender, reciever, sender.weapon.atkDamage, sender.weapon.EffectType);
        //sends that to the target
        reciever.receiveAttack(attack);
        //destroys the object
        GameObject.DestroyImmediate(attack);
    }


    /*
     * Summary:     Preps everybody in the tile for combat. The combat bool is set to true,
     *              the hero's attackTimer gets reset, and the acting npcs move into action
     * 
     * Parameters:  none
     * 
     * Returns:     nothing
     */
    void EnterCombat()
    { 
        centerPosition = hero.transform.position;
        //allows combat manager to process combat
        inCombat = true;

        enemies[currentEnemy].GetComponent<Enemy>().transform.position =
    enemies[currentEnemy].GetComponent<Enemy>().combatAI.EngageCombat(enemies[currentEnemy].GetComponent<Enemy>().transform.position);

        hero.transform.position = hero.combatAI.EngageCombat(enemies[currentEnemy].GetComponent<Enemy>().transform.position);

        //reset hero attack timer since it runs constantly out of combat
        hero.attackTimer = 0;
    }


    /*
     * Summary:     Function that fills the enemies array. The hero npc will set
     *              a flag saying it has the enemies, and this function gets called
     *              to fill them into this array. The flag will be set each time the
     *              hero enters the tile. I know this is unreasonably high coupling,
     *              but I didn't know a better way to do this
     * 
     * Parameters:  None
     * 
     * Returns:     Nothing
     */
    void CollectEnemy()
    {
        //Gets the length of the list of enemies in the room, if it's clear the flag and keep moving
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

            //This looks ugly, it just has the enemy move toward the hero to easily see who's being attacked
            enemies[currentEnemy].GetComponent<Enemy>().transform.position =
                enemies[currentEnemy].GetComponent<Enemy>().combatAI.EngageCombat(enemies[currentEnemy].GetComponent<Enemy>().transform.position);

            //resets the collection flag on the hero
            hero.collectEnemy = false;

            //begins combat
            EnterCombat();
        }
        //this is the skip option if the list on the hero is empty
        else
        {
            hero.EndCombat();
            hero.collectEnemy = false;
        }
    }
}