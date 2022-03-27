using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTile : MonoBehaviour {
   public int exit;
   public int indX, indY;
   public GameObject DoorReminder;
   public GridManager GridManager;
   public List<GameObject> enemy;
   public List<GameObject> doors;
   void Start() {
      Debug.Log("Tile Created");
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
      
   }

   void Update() {
      //if (DoorReminder.active) {
         if (Input.GetKeyDown("left")) {
            SetExit(0);
            //DoorReminder.SetActive(false);
         }
         if (Input.GetKeyDown("right")) {
            SetExit(1);
            //DoorReminder.SetActive(false);
         }
         if (Input.GetKeyDown("up")) {
            SetExit(2);
            //DoorReminder.SetActive(false);
         }
         if (Input.GetKeyDown("down")) {
            SetExit(3);
            //DoorReminder.SetActive(false);
         }
      //}
   }

   void SetExit(int arg) {
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