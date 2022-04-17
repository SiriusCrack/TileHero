/*
 * Filename: EmptyTile.cs
 * Developer: Ian Fleming
 * Purpose: This script contains implementations for the empty tile object.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: EmptyTile class contains all the implementations for the empty tile.
 * 
 * Member Variables:
 * cursorTexture - Texture of the select/hover cursor
 * cursorMode - Behavior of the cursor
 * hotSpot - Value to reset the cursor
 * indX - X index of the tile
 * indY - Y index of the tile
 * highlight - Game object placeholder for the highlight effect
*/
public class EmptyTile : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    public int indX;
    public int indY;

    [SerializeField] public GameObject highlight;


    /*
     * Summary: Function call when mouse enters the object.
     *
     * Parameters: None
     *
     * Returns: None
    */
    public virtual void OnMouseEnter() {
        highlight.SetActive(true);
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }


    /*
     * Summary: Function call when mouse exits the object.
     *
     * Parameters: None
     *
     * Returns: None
    */
    public virtual void OnMouseExit() {
        highlight.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }


    /*
     * Summary: Function call when mouse clicks the object.
     *
     * Parameters: None
     *
     * Returns: None
    */
    public virtual void OnMouseDown() {
        var GM = GameObject.Find("GridManager");
        GM.SendMessage("SetTile", this.gameObject);
    }
}