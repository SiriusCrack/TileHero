using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTile : MonoBehaviour {
   public int exit;
   public int indX, indY;
   public GameObject DoorReminder;
   public GridManager GridManager;
   public GameObject thisTile;
   public List<GameObject> enemy;
   public List<GameObject> doors;
   void Start() {
      Debug.Log("Tile Created");
      exit = 5;
      enemy = new List<GameObject>();
      doors = new List<GameObject>();
      for (int i = 0; i < this.gameObject.transform.childCount; i++) {
         if (this.gameObject.transform.GetChild(i).gameObject.tag == "enemy")
            enemy.Add(this.gameObject.transform.GetChild(i).gameObject);
         if (this.gameObject.transform.GetChild(i).gameObject.tag == "door")
            doors.Add(this.gameObject.transform.GetChild(i).gameObject);
      }
      GridManager = this.transform.parent.GetComponent<GridManager>();
      //DoorReminder = GameObject.Find("DoorReminder").gameObject;
      //DoorReminder.SetActive(true);
      thisTile = this.gameObject;
   }

   void Update() {
      if (exit == 5) {
         if (Input.GetKeyDown("left")) {
            Debug.Log(indX);
            GridManager.SetDirection(indX, indY, 1, thisTile);
            //DoorReminder.SetActive(false);
         }
         if (Input.GetKeyDown("right")) {
            GridManager.SetDirection(indX, indY, 0, thisTile);
            //DoorReminder.SetActive(false);
         }
         if (Input.GetKeyDown("up")) {
            GridManager.SetDirection(indX, indY, 3, thisTile);
            //DoorReminder.SetActive(false);
         }
         if (Input.GetKeyDown("down")) {
            GridManager.SetDirection(indX, indY, 2, thisTile);
            //DoorReminder.SetActive(false);
         }
      }
   }

   public void SetExit(int arg) {
      exit = arg;
      switch(arg) {
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
                Debug.Log("no exit");
                break;
      }
   }
}