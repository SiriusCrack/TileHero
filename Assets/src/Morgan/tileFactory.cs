using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileFactory : MonoBehaviour
{
    [SerializeField] levelTile TileType1, TileType2;
    
    public levelTile GetNewTile(levelTile Tile) {
        return Instantiate(Tile);
    }
}