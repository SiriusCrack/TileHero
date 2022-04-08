using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void setAttributes(NPC issuer, NPC target, float power, int effectType)
    {
        sender = issuer;
        receiver = target;
        damage = power;
        effect = effectType;
    }
}
