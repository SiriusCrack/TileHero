using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTile : MonoBehaviour
{ 
   [SerializeField] private bool connected;
   public int exit;
   public int indX, indY;
   public GameObject thisTile;
   public GameObject doorReminder;
   public GridManager gridManager;
   public List<GameObject> enemy;
   public List<GameObject> doors;


   void Start()
   {

      connected = false;
      Debug.Log("Custom Tile Type Initialized (" + this.gameObject.name + ")");
      
      enemy = new List<GameObject>();
      doors = new List<GameObject>();

      for (int i = 0; i < this.gameObject.transform.childCount; i++) {
         if (this.gameObject.transform.GetChild(i).gameObject.tag == "enemy")
            enemy.Add(this.gameObject.transform.GetChild(i).gameObject);
         if (this.gameObject.transform.GetChild(i).gameObject.tag == "Door")
            doors.Add(this.gameObject.transform.GetChild(i).gameObject);
      }

      gridManager = this.transform.parent.GetComponent<GridManager>();
   }


   void Awake()
   {
      thisTile = this.gameObject;
   }


   void Update()
   {
      thisTile = this.gameObject;
      if ( connected == false ) {
         connected = GetDoorInput(indX, indY, thisTile);
      }
   }


   public bool GetDoorInput(int x, int y, GameObject tile)
   {

      if( Input.GetKeyDown("up") ) {
         return gridManager.SetDirection(x, y, 0, tile);
      }
      else if( Input.GetKeyDown("right") ) {
         return gridManager.SetDirection(x, y, 1, tile);
      }
      else if( Input.GetKeyDown("down") ) {
         return gridManager.SetDirection(x, y, 2, tile);
      }
      else if( Input.GetKeyDown("left") ) {
         return gridManager.SetDirection(x, y, 3, tile);
      }
      else {
         return false;
      }
   }


   public void SetExit(int dir)
   {
      exit = dir;
      switch (dir)
      {
         case 0:
            doors[0].SetActive(true);
            break;
         case 1:
            doors[1].SetActive(true);
            break;
         case 2:
            doors[2].SetActive(true);
            break;
         case 3:
            doors[3].SetActive(true);
            break;
         default:
            Debug.Log("Error in SetExit() :: Placing door.");
            break;
      }
   }
}