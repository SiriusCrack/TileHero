/*
 * Filename: TileThumb.cs
 * Developer: Morgan Brockman
 * Purpose: This file acts as the script for the tile thumbnail images, or buttons in the Tile Inventory interface.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 * Summary: Converts tile thumbnail images for the Tile Inventory buttons into their respective TileType prefabs.
 * 
 * Member Variables:
 * tileInventory - A special variable which references the script for the Tile Inventory.
 * cursorTexture - A special texture for the cursor to change to when mousing-over this script's parent tileThumb.
 * cursorMode - A variable which must be set for changing the cursor when mousing-over.
 * hotSpot - A Vector for denoting when the cursor has moused over this script's parent tileThumb.
 * localSelect - A boolean for denoting locally whether this tileThumb has been selected. 
 */
public class TileThumb : MonoBehaviour, IPointerEnterHandler
{
    TileInventory tileInventory;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    private bool localSelect = false;


    /*
     * Summary: Initializes the TileInventory script.
     * 
     * Parameters:
     * none.
     * 
     * Returns:
     * none.
     */
    void Start()
    {
        tileInventory = GetComponentInParent<TileInventory>();
    }


    /*
     * Summary: Special Unity IPointerEnterHandler method called when this tileThumb is moused-over.
     * 
     * Parameters:
     * eventData - Boilerplate IPointerEnterHandler variable
     * 
     * Returns:
     * none.
     */
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }


    /*
     * Summary: Special Unity IPointerEnterHandler method called when this tileThumb is no longer moused-over.
     * 
     * Parameters:
     * eventData - Boilerplate IPointerEnterHandler variable
     * 
     * Returns:
     * none.
     */
    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }


    /*
     * Summary: Is called by this tileThumb's button when pressed. Highlights or un-highlights the tileThumb depending on if it's selected, then uses Unity's SendMessage() method to call TileInventory's PickTile() method to set the selected tile.
     * 
     * Parameters:
     * none.
     * 
     * Returns:
     * none.
     */
    public void SelectTile()
    {
        tileInventory = GetComponentInParent<TileInventory>();

        Debug.Log("Tile selected");

        if (tileInventory.globalSelect == false && localSelect == false) {
            tileInventory.globalSelect = true;
            localSelect = true;
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Debug.Log(this.gameObject.name + " selected.");
            tileInventory.SendMessage("PickTile", this.gameObject);
        }
        else if (tileInventory.globalSelect == true && localSelect == true) {
            tileInventory.globalSelect = false;
            localSelect = false;
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Debug.Log(this.gameObject.name + " deselected.");
            tileInventory.SendMessage("PickTile", this.gameObject);
        }
        else if (tileInventory.globalSelect == true && localSelect == false) {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Debug.Log("Only one tile type can be selected.");
        }
    }
}