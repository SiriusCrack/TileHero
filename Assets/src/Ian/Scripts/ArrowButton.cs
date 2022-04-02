using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButton : MonoBehaviour
{

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    public void EnableCursor() {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public void DisableCursor() {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

}
