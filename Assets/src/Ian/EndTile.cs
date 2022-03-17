using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTile : Tile
{
    public override void OnMouseEnter() {
        highlight.SetActive(false);
        select.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public override void OnMouseExit() {
        highlight.SetActive(false);
        select.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public override void OnMouseDown() {
        highlight.SetActive(false);
        select.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
