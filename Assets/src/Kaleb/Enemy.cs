using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NPC;

public class Enemy : NPC
{
    // Start is called before the first frame update
    private bool messagePrinted;
    public Enemy thisEnemy;
    void Start()
    {
        thisEnemy = this;
        //messagePrinted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Move(int heroLocation)
    {
        
    }

    void FixedUpdate()
    {
        attackTimer += 1;
    }

}

