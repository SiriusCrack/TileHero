/*
 * Filename: StartTile.cs
 * Developer: Ian Fleming
 * Purpose: This script contains implementations for the start tile object
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: StartTile class contains all the implementations for the start tile.
 * 
 * Member Variables:
 * exit - value that communicates the direction of the door
*/

/* This class contains override methods. The keyword override, as defined by Microsoft for C#, is required
 * to extend or modify the abstract or virtual implemetation of an inherited method, property
 * indexer, or event.
*/

// This class inherits from the EmptyTile class //
public class StartTile : EmptyTile
{
    public int exit;


    /*
     * Summary: Function call at object creation/game start. Sets the exit variable.
     *
     * Parameters: None
     *
     * Returns: None
    */
    void Start() {
        exit = -1;
    }


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