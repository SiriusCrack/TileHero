/*
 * Filename: TileInventory.cs
 * Developer: Morgan Brockman
 * Purpose: This file acts as the script for the TileInventory
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Converts tile thumbnail images for the Tile Inventory buttons into their respective TileType prefabs.
 * 
 * Member Variables:
 * selectedTile - A GameObject which stores the currently-selected tile type for access by the GridManager when placing tiles.
 * tileTypeX - A GameObject for referencing the prefab of a given tile type.
 * thumbX - A GameObject for referencing the image thumbnail of a given tile type.
 * globalSelect - A boolean for denoting whether a tile is currently selected by the Tile Inventory.
 */
public class TileInventory : MonoBehaviour
{
    public GameObject selectedTile = null;
    [SerializeField] private GameObject tileTypeA, tileTypeB;
    [SerializeField] private GameObject thumbA, thumbB;
    public bool globalSelect = false;


    /*
     * Summary: Takes a given tile thumbnail image and stores the respective tile type prefab as the Tile Inventory's selected tile.
     * 
     * Parameters:
     * selectedThumb - A GameObject image which denotes a certain tile type prefab.
     * 
     * Returns:
     * none.
     */
    void PickTile(GameObject selectedThumb)
    {
        if (selectedThumb == thumbA) {
            selectedTile = tileTypeA;
        }
        if (selectedThumb == thumbB) {
            selectedTile = tileTypeB;
        }
    }
}