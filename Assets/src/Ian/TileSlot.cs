using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSlot : MonoBehaviour {

    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    [SerializeField] private GameObject highlight;
    [SerializeField] private GameObject select;

    private int selected = 0;

    void OnMouseEnter() {
        if( selected == 1 ) {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            return;
        }
        else {
            highlight.SetActive(true);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }    
    }

    void OnMouseExit() {
        highlight.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    void OnMouseDown() {
        if( selected == 1 ) {
            selected = 0;
            select.SetActive(false);
            highlight.SetActive(true);
            Debug.Log(this.gameObject.name + " deselected." );
        }
        else {
            selected = 1;
            highlight.SetActive(false);
            select.SetActive(true);
            Debug.Log(this.gameObject.name + " selected.");
        }
    }
}
