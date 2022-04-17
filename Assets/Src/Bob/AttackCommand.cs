/*
 * Filename: AttackCommand.cs
 * Developer: Robert Walko
 * Purpose: contains the AttackCommand class
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Allows the combatmanager to send attacks to npcs
 * 
 * Member Variables:
 * sender   the npc who made the attack
 * reciever the npc getting hurt
 * damage   the amount of damage the attack will do
 * effect   this int will tell the reciever whether they need
 *          to apply extra effects like bleed or poison to the
 *          attack
 */
public class AttackCommand : MonoBehaviour
{
    public NPC sender;
    public NPC receiver;
    public float damage;
    public int effect;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Summary: Sets all the variables within the command. Should
     *          only be used by the combat manager
     * 
     * Parameters:
     * issuer:      the sender
     * target:      the reciever
     * power:       the damage
     * effectType:  the effect
     * 
     * Returns:
     * Nothing
     */
    public void SetAttributes(NPC issuer, NPC target, float power, int effectType)
    {
        sender = issuer;
        receiver = target;
        damage = power;
        effect = effectType;
    }
}
