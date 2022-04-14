using static NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hero : NPC
{
    public ShopMenu inventory;
    
    private bool inCombat = false; //Bob Variable

    private float distTraveled = 0f;
    [SerializeField]
    private int nextDirection;

    private bool hasDirection;
    private GameObject currentTile, AmbientMusic;
    private bool isMoving;

    public Enemy currentEnemy; //Bob Variable
    [SerializeField]
    public bool collectEnemy = false; //Bob Variable
    public List<GameObject> enemies; //Bob Variable
    int left = 0;

    [SerializeField]
    bool inDemo = false;


    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        combatAI.setMaxHealth(health);
        combatAI.updateLocation(transform.position);
        weapon = MainManager.Instance.playerWeapon;
        health = MainManager.Instance.playerHealth;
        setAtk(MainManager.Instance.playerAtk);
        AmbientMusic= GameObject.FindWithTag("Music");
        AmbientMusic.SetActive(false);
        currentTile = GameObject.FindWithTag("Start");
        nextDirection = currentTile.GetComponent<StartTile>().exit;
        print("Enabled the Hero");
        print("Current Direction: " + nextDirection);
        //nextDirection = 1;
        hasDirection = true;
        isMoving = false;
        inCombat = false;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("IsMoving: " + isMoving + " , HasDirection: " + hasDirection);
    }
    void FixedUpdate()
    {
        combatAI.updateLocation(transform.position);
        // Debug.Log("IsMoving: " + isMoving + " , HasDirection: " + hasDirection);
        //やった! ゴールゲット
        if (!inCombat)
        {
            if (hasDirection && !isMoving)
            {
                StartCoroutine(Move(nextDirection));
            }
            if(!hasDirection && !isMoving)
            {
                GetNextDirection();
            }
        }
        else
        {
            //Debug.Log("Attack Timer");
            //Debug.Log(attackTimer);
            attackTimer += 1;
        }

    }

    void GetNextDirection()
    {
        
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

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Collision here");
        if (other.tag == "LevelTile")
        {
            //Debug.Log("Real tile collided");
            /*Bob: start combat should prevent movement, enemies = ... will store
            the enemies from the tile in the hero, then collectEnemy being set to
            true will tell the combat manager to pick them up off the hero*/ 
            StartCombat();
            enemies = other.GetComponent<LevelTile>().enemy;
            collectEnemy = true;

            nextDirection = other.GetComponent<LevelTile>().exit;
            print("Next Direction: " + nextDirection);
            hasDirection = true;
        }
        if (other.tag == "Start")
        {
           nextDirection = other.GetComponent<StartTile>().exit;
            print("Next Direction: " + nextDirection);
            hasDirection = true;
            isMoving = false;
        }
        if(other.tag == "End")
        {
            SceneManager.LoadScene("StartMenu");
            if(inDemo)
            {
                SceneManager.LoadScene("StartMenu");
            }
            gameObject.SetActive(false);
        }
    }

    //move hero automatically between tiles
    //takes in the direction of the next tile
    //moves hero by a set distance in direction specified

    public override IEnumerator Move(int nextDirection)
    {
        print("Moving now");
        distTraveled = 0f;
        hasDirection = false;
        isMoving = true;
        //move right one tile
        if(nextDirection == 1)
        {
            while(distTraveled < 1.0f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(.01f,0,0);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                //Debug.Log(transform.position);
                yield return new WaitForSeconds(.01f);
            }
            isMoving = false;
        }

        //move left one tile
        if(nextDirection == 3)
        {
             while(distTraveled < 1.0f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(-.01f,0,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                //Debug.Log(transform.position);
                yield return new WaitForSeconds(.01f);
            }
            isMoving = false;
        }

        //move up one tile
        if(nextDirection == 0)
        {
             while(distTraveled < 1.0f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(0,0.01f,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
               // Debug.Log(transform.position);
                yield return new WaitForSeconds(.01f);
            }
            isMoving = false;
        }

        //move down one tile
        if(nextDirection == 2)
        {
             while(distTraveled < 1.0f)
            {
                Vector3 oldPosition = transform.position;
                transform.Translate(0,-0.01f,0*Time.deltaTime);
                distTraveled += Vector3.Distance(oldPosition, transform.position);
                //Debug.Log(transform.position);
                yield return new WaitForSeconds(.01f);
            }
            isMoving = false;
        }
    }
}
