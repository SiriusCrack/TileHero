/*
 * Filename:    HeroAI
 * Developer:   Robert Walko
 * Purpose:     Contains the HeroAI class
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Summary:             A subclass of the CombatAI class for the Hero.
 *                      changes EngageCombat so that the hero steps away
 *                      from the enemy when they approach
 * 
 * Member Variables:
 * yDist:   the difference in y coordinates of the hero and the current enemy,
 *          Used in EngageCombat
 * xDist:   the difference in x coordinates of the hero and the current enemy,
 *          Used in EngageCombat
 */
public class HeroAI : CombatAI
{
    float yDist;
    float xDist;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    /*
     * Summary:     Makes it so the hero moves back when the enemy approaches.
     *              Doesn't do anything helpful, just looks nice.
     *              The calculations are to double the distance from the enemy
     *              after the enemy has closed in. It doesn't seem to move as far
     *              as that though, which is fine. It still looks nice. needs a test
     *              to ensure they don't leave the tile.
     * 
     * Parameters:  the location of the enemy apporaching the hero
     * 
     * Returns:     the location the hero will move to
     */
    public override Vector3 EngageCombat(Vector3 npcL)
    {
        heroPos = GameObject.FindGameObjectWithTag("hero").transform.position;
        float yDist = npcL.y - heroPos.y;
        float xDist = npcL.x - heroPos.x;
        targetLocation = new Vector3(heroPos.x - xDist, heroPos.y - yDist, heroPos.z);
        return targetLocation;
    }
}
