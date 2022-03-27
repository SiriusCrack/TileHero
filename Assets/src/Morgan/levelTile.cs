using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTile : MonoBehaviour {
   public int exit;
   public int indX, indY;
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
      SetExit(1);
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