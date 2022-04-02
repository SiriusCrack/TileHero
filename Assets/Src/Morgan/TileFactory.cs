using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFactory : MonoBehaviour
{
    [SerializeField] GameObject tileTypeA, tileTypeB;
    
    
    public GameObject GetNewTile(GameObject tile)
    {
        return Instantiate(tile, new Vector3(0,0), Quaternion.identity);
    }
}