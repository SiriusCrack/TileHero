using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileFactory : MonoBehaviour
{
    [SerializeField] GameObject TileType1, TileType2;
    
    public GameObject GetNewTile(GameObject Tile) {
        return Instantiate(Tile, new Vector3(0,0), Quaternion.identity);
    }
}