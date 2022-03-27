using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : MonoBehaviour
{
    public NPC sender;
    public NPC receiver;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AttackCommand(NPC issuer, NPC target, float power)
    {
        sender = issuer;
        receiver = target;
        damage = power;
    }
}
