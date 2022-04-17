/*
 * Filename: LevelTile.cs
 * Developer: Morgan Brockman
 * Purpose: This file acts as the script for the LevelTile prefab
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Contains data and methods for the LevelTile objects to function within the broader game
 * 
 * Member Variables:
 * connected - A boolean which denotes whether or not the parent tile object has a door connecting it to an adjacent tile.
 * exit - An integer encoding the direction of the door which is the exit for this script's parent tile. Ex: 0 - North, 1 - East, etc.
 * intX and indY - Integers which store the location of the parent tile's position within the "Grid" by a simple two-dimensional Cartesian X/Y coordinate system.
 * thisTile - A GameObject for referencing the GameObject of this script's parent tile. Implemented for more explicit object passing to avoid bugs.
 * gridManager - A special variable for referencing the Grid Manager script.
 * enemy - A list of GameObjects for storage of all enemy GameObjects present on this tile. This list is referenced by the Combat Manager.
 * doors - A list of the door GameObjects for reference when activating / deactivating according to this tile's exit.
 */
public class LevelTile : MonoBehaviour
{ 
   [SerializeField] public bool connected;
   public int exit;
   public int indX, indY;
   //public GameObject thisTile;
   public GridManager gridManager;
   public List<GameObject> enemy;
   public List<GameObject> doors;

   /*
    * Summary: Initializes variables, such as the connected boolean, its enemy list, and its GridManager.
    * 
    * Parameters:
    * none.
    * 
    * Returns:
    * none.
    */
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

   /*
    * Summary: If this tile is connected, this function does nothing. If it is not connected, it repeatedly calls GetDoorInput().
    * 
    * Parameters:
    * none.
    * 
    * Returns:
    * none.
    */
   void Update()
   {
      //thisTile = this.gameObject;
      if ( connected == false ) {
         //if (thisTile != null) {
            connected = GetDoorInput(indX, indY, this.gameObject);
         //}
      }
   }

   /*
    * Summary: Calls the Grid Manager method SetDirection() (according to the user's input), which ultimately calls another tile's (depending on the user's input) SetExit() method. 
    * 
    * Parameters:
    * x and y - Cartesion coordinates of this tile's location on the Grid.
    * tile - GameObject which is this scripts parent tile.
    * 
    * Returns:
    * Boolian - Returns true if the tile's exit is set correctly, so this tile can be marked as connected.
    */
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

   /*
    * Summary: Is called by the grid manager with the direction of the exit to be set as an argument. It then sets the exit and activates the respective door GameObject.
    * 
    * Parameters:
    * dir - an integer denoting the direction of the exit to be set, much like the global exit integer mentioned earlier.
    * 
    * Returns:
    * none.
    */
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