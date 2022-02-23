using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{  
   [SerializeField]
   private int rows = 1; // Change amount of rows the grid has.
   [SerializeField]
   private int cols = 3; // Change amount of cols the grid has.
   [SerializeField]
   private float tileSize = 1; // Changes padding of the tiles.

   void Start() {
      GenerateGrid();
   }

   private void GenerateGrid()
   {
      GameObject emptyTile = (GameObject)Instantiate(Resources.Load("EmptyTile"));
      for(int row = 0; row < rows; row++) {
         for (int col = 0; col < cols; col++) {
            GameObject tile = (GameObject)Instantiate(emptyTile, transform);

            float posX = col * tileSize;
            float posY = row * tileSize;

            tile.transform.position = new Vector2(posX, posY);
         }
      }
      Destroy(emptyTile);

      float gridW = cols * tileSize;
      float gridH = rows * -tileSize;
      transform.position = new Vector2((-gridW / 2) + (tileSize / 2), 0); // Use '(gridH / 2) - (tileSize / 2)' if rows > 1.
   }

}