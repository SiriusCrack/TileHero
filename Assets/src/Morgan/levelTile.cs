using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTile : MonoBehaviour {
   public int exit;
   public int indX, indY;
   void Start() {
      Debug.Log("Tile Created");
   }

   void SetExit(int arg) {
      exit = arg;
   }
}
