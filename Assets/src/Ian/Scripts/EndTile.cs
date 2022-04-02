/*
 * Filename: EndTile.cs
 * Developer: Ian Fleming
 * Purpose: This script contains implementations for the end tile object.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: EndTile class contains all the implementations for the empty tile.
 * 
 * Member Variables: None
*/
public class EndTile : EmptyTile
{

    /*
     * Summary: Function call when mouse enters the object.
     *
     * Parameters: None
     *
     * Returns: None
    */
    public override void OnMouseEnter() {
        highlight.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }


    /*
     * Summary: Function call when mouse exits the object.
     *
     * Parameters: None
     *
     * Returns: None
    */
    public override void OnMouseExit() {
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
    public override void OnMouseDown() {
        highlight.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}