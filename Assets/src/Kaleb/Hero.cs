using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static NPC;

public class Hero : NPC
{
    public Weapon weapon;
    public ShopMenu inventory;
    private bool incombat = false;
    private float distTraveled = 0f;
    private float finalCoordinates; 
    // Start is called before the first frame update
    void Start()
    {
        //finalCoordinates = GameObject.FindGameObjectWithTag("EndTile").transform.localPosition.x;
        //print(finalCoordinates);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //やった! ゴールゲット
        if(transform.position.x > 1.8)
        {
            Time.timeScale = 0;
            inventory.showInterface();
            
        }
        if(!incombat)
        {
            Move(1);
        }
    }


    public void Attack(Weapon weapon)
    {
        print("Attack: " + weapon.atk_damage);
    }
    //move hero automatically between tiles
    //takes in the direction of the next tile
    //moves hero by a set distance in direction specified
    public override void Move(int nextDirection)
    {
        distTraveled = 0f;
        //move right one tile
        if(nextDirection == 1)
        {
            if(distTraveled < 1.15f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(.05f,0,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                //Debug.Log(transform.position);
            }
        }

        //move left one tile
        if(nextDirection == 2)
        {
             if(distTraveled < 1.15f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(-.05f,0,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                Debug.Log(transform.position);
            }
        }

        //move up one tile
        if(nextDirection == 3)
        {
             if(distTraveled < 1.15f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(0,0.05f,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                Debug.Log(transform.position);
            }
        }

        //move down one tile
        if(nextDirection == 4)
        {
             if(distTraveled < 1.15f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(0,.05f,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                Debug.Log(transform.position);
            }
        }
    }
}
