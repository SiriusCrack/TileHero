using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NPC;

public class Hero : NPC
{
    private bool incombat = false;
    private float distTraveled = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
        if(!incombat)
        {
            Move(1);
        }
    }
    public override void Move(int nextDirection)
    {

        if(nextDirection == 1)
        {
            if(distTraveled < 5f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(1,0,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                Debug.Log(transform.position);
            }
        }
        if(nextDirection == 2)
        {
             if(distTraveled < 5f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(-1,0,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                Debug.Log(transform.position);
            }
        }
        if(nextDirection == 3)
        {
             if(distTraveled < 5f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(0,1,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                Debug.Log(transform.position);
            }
        }
        if(nextDirection == 4)
        {
             if(distTraveled < 5f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(0,-1,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                Debug.Log(transform.position);
            }
        }
    }
}
