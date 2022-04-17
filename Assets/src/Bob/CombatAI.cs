/*
 * Filename:    CombatAI.cs
 * Developer:   Robert Walko
 * Purpose:     Contains the combatAI class
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Summary: The combatAI currently manages the healthbar and the
 *          in combat movement. Essentially, it serves to separate
 *          my contributions to the npcs from Kaleb's, as the combat
 *          AI only handles combat related npc tasks
 * 
 * Member Variables:
 * health:          the current health of the npc the AI belongs to
 * maxHealth:       the max hp of the npc the AI belongs to
 * barLocation:     used in the UpdateLocation function to store where the
 *                  the healthbar should be in relation to the npc it is
 *                  attached to
 * targetLocation:  used in the EngageCombat function to store where the 
 *                  npc will move to at the end of the function
 *                  
 * heroPos:         the position of the hero when EngageCombat is called
 * healthBar:       the healthbar belonging to this AI. It will follow the 
 *                  npc this AI is attached to and display their current health
 *                 
 * healthBarSlider: the component on the healthbar that allows the healthbar to
 *                  track player health. 1 displays the full red bar, 0 is all gray
 */
public class CombatAI : MonoBehaviour
{
    float health;
    float maxHealth;

    Vector3 barLocation;
    public Vector3 targetLocation;

    public Vector3 heroPos;

    public GameObject healthBar;
    public Slider healthBarSlider;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    * Summary: This function is called when an npc is created/awakened 
    * to set its max health. The healthbar display is based on the
    * ratio of current health to maxHealth
    * 
    * Parameters: 
    * tempMaxHealth:    it's called temp because we can't have two
    *                   variables called maxhealth
    * 
    * Returns:
    * Nothing
    */
    public void SetMaxHealth(float tempMaxHealth)
    {
        maxHealth = tempMaxHealth;
        //since the npc was just created, their health and max health
        //should be the same
        health = tempMaxHealth;
    }

    /*
     * Summary: Updates the healthbar display. the slider gets set to
     * the ratio of health to max health, which will shrink the bar
     * 
     * Parameters:
     * tempHealth:  can't have two variables called health. This is
     * just the health being passed from the NPC
     * 
     * Returns:
     * Nothing
     */
    public void UpdateSlider(float tempHealth)
    {
        health = tempHealth;
        healthBarSlider.value = health / maxHealth;
    }

    /*
     * Summary: The healthbar needs to move with the NPC, so
     * this function takes the npc's location and moves the
     * healthbar just below
     * 
     * Parameters:
     * npcLocation: the location of the NPC
     * 
     * Returns:
     * Nothing
     */
    public void UpdateLocation(Vector3 npcLocation)
    {
        barLocation = new Vector3(npcLocation.x, npcLocation.y - .15f, npcLocation.z);
        healthBar.transform.position = Camera.main.WorldToScreenPoint(barLocation);
    }

    /*
     * Summary: Gives a visual indication of the enemy the hero is fighting. This
     * function will be called at the start of combat and whenever an enemy dies.
     * The enemy will move have the distance toward the hero. This is a virtual 
     * function which will be overriden in the hero's script.
     * 
     * Parameters:
     * npcL:    the npc's location just like above
     * 
     * Returns:
     * targetLocation:  the position halfway between the hero and enemy that the
     *                  enemy will move to
     */
    public virtual Vector3 EngageCombat(Vector3 npcL)
    {
        //This will look for an object with the tag hero. If we expand this game
        //to include multiple heroes we will need to change this
        heroPos = GameObject.FindGameObjectWithTag("hero").transform.position;
        float yDist = npcL.y - heroPos.y;
        float xDist = npcL.x - heroPos.x;
        targetLocation = new Vector3(npcL.x - (xDist / 2), npcL.y - (yDist / 2), npcL.z);
        return targetLocation;
    }
}
