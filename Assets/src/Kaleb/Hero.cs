using static NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hero : NPC
{
    public ShopMenu inventory;
    private bool inCombat = false;

    private float distTraveled = 0f;
    private int nextDirection;
    private bool hasDirection;
    private float finalCoordinates;
    private bool isMoving;

    public Enemy currentEnemy;
    public bool collectEnemy = false;
    int left = 0;

    // Start is called before the first frame update
    void Start()
    {
        nextDirection = 1;
        hasDirection = true;
        isMoving = false;
    }
    void Awake()
    {
        print("Enabled the Hero");
        nextDirection = 1;
        hasDirection = true;
        isMoving = false;
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown("p"))
       // {
       //     SetTime();
       // }
    }
    void FixedUpdate()
    {
        //やった! ゴールゲット
        if(!inCombat)
        {
            if(hasDirection && !isMoving)
            {
                StartCoroutine(Move(nextDirection));
            }
            if(!hasDirection && !isMoving)
            {
                GetNextDirection();
            }
        }

    }

    void GetNextDirection()
    {
        print("Waiting for next Direction");
    }
    public void SetTime()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            print("Game Resume");
        }else{
            Time.timeScale = 0;
            print("Game Pause");
        }
    }

    public void StartCombat()
    {
        inCombat = true;
    }
    public void EndCombat()
    {
        inCombat = false;
    }

    public void Attack(Weapon weapon)
    {
        print("Attack: " + weapon.atkDamage);
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            currentEnemy = other.GetComponent<Enemy>().thisEnemy;
            collectEnemy = true;
            Debug.Log(currentEnemy);
        }
    }*/

    //move hero automatically between tiles
    //takes in the direction of the next tile
    //moves hero by a set distance in direction specified

    public override IEnumerator Move(int nextDirection)
    {
        distTraveled = 0f;
        hasDirection = false;
        isMoving = true;
        //move right one tile
        if(nextDirection == 1)
        {
            while(distTraveled < 1.0f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(.05f,0,0);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                //Debug.Log(transform.position);
                yield return new WaitForSeconds(.05f);
            }
            isMoving = false;
        }

        //move left one tile
        if(nextDirection == 3)
        {
             while(distTraveled < 1.0f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(-.05f,0,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                Debug.Log(transform.position);
                yield return new WaitForSeconds(.05f);
            }
            isMoving = false;
        }

        //move up one tile
        if(nextDirection == 0)
        {
             while(distTraveled < 1.0f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(0,0.05f,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                Debug.Log(transform.position);
                yield return new WaitForSeconds(.05f);
            }
            isMoving = false;
        }

        //move down one tile
        if(nextDirection == 2)
        {
             while(distTraveled < 1.0f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(0,.05f,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                Debug.Log(transform.position);
                yield return new WaitForSeconds(.05f);
            }
            isMoving = false;
        }
    }
}
