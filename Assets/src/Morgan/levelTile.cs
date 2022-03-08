using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelTile : MonoBehaviour {
   float data;
   void Start() {
      Debug.Log("Tile Created");
      data = Random.value;
   }

   void FixedUpdate() {
      data = data * Random.value;
   }
}
