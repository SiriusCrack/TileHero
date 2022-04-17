/*
 * Filename: TileFactory.cs
 * Developer: Morgan Brockman
 * Purpose: This file acts as the factory for LevelTile prefab objects.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Takes a prefab and produces a new GameObject
 * 
 * Member Variables:
 * none.
 */
public class TileFactory : MonoBehaviour
{
    /*
     * Summary: Initializes variables, such as the connected boolean, its enemy list, and its GridManager.
     * 
     * Parameters:
     * tile - The type of tile to be created.
     * 
     * Returns:
     * GameObject - The created tile.
     */
    public GameObject GetNewTile(GameObject tile)
    {
        return Instantiate(tile, new Vector3(0,0), Quaternion.identity);
    }
}