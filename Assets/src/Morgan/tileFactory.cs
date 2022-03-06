using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileFactory : MonoBehaviour
{
    [SerializeField] levelTile TileType1, TileType2;
    
    public levelTile GetNewTile(int tile) {
        if (tile == 2) {
            return Instantiate(TileType2);
        } else {
            return Instantiate(TileType1);
        }
    }
}