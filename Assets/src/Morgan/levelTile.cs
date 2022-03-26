using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTile : MonoBehaviour {
   public int exit;
   void Start() {
      Debug.Log("Tile Created");
   }

   void SetExit(int arg) {
      exit = arg;
   }
}
