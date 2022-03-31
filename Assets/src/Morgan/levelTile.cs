using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTile : MonoBehaviour { 
   [SerializeField] private bool connected;
   public int exit;
   public int indX, indY;
   public GameObject DoorReminder;
   public GridManager GridManager;
   public List<GameObject> enemy;
   public List<GameObject> doors;

   void Start() {
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

      GridManager = this.transform.parent.GetComponent<GridManager>();

   }

   void Update() {
      if( connected == false ) {
         connected = getDoorInput(indX, indY, this.gameObject);
      }
   }

   public bool getDoorInput(int x, int y, GameObject tile) {

      if( Input.GetKeyDown("up") ) {
         return GridManager.SetDirection(x, y, 0, tile);
      }
      if( Input.GetKeyDown("right") ) {
         return GridManager.SetDirection(x, y, 1, tile);
      }
      if( Input.GetKeyDown("down") ) {
         return GridManager.SetDirection(x, y, 2, tile);
      }
      if( Input.GetKeyDown("left") ) {
         return GridManager.SetDirection(x, y, 3, tile);
      }
      else {
         return false;
      }
   }

   public void SetExit(int dir) {
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