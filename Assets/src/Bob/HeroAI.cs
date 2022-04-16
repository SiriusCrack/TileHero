using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public override Vector3 engageCombat(Vector3 npcL)
    {
        heroPos = GameObject.FindGameObjectWithTag("hero").transform.position;
        float yDist = npcL.y - heroPos.y;
        float xDist = npcL.x - heroPos.x;
        targetLocation = new Vector3(heroPos.x - xDist, heroPos.y - yDist, heroPos.z);
        return targetLocation;
    }
}
