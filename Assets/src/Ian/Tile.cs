using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    [SerializeField] public GameObject highlight;
    [SerializeField] public GameObject select;

    int localSel = 0;
    
    public virtual void OnMouseEnter() {
        highlight.SetActive(true);
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public virtual void OnMouseExit() {
        highlight.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public virtual void OnMouseDown() {
        if ( this.transform.parent.GetComponent<GridManager>().globalSel == 0 && localSel == 0 )
        {
            this.transform.parent.GetComponent<GridManager>().globalSel = 1;
            localSel = 1;
            select.SetActive(true);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Debug.Log(this.gameObject.name + " selected.");
        }
        else if ( this.transform.parent.GetComponent<GridManager>().globalSel == 1 && localSel == 1 ) {
            this.transform.parent.GetComponent<GridManager>().globalSel = 0;
            localSel = 0;
            select.SetActive(false);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Debug.Log(this.gameObject.name + " deselected.");
        }
        else if ( this.transform.parent.GetComponent<GridManager>().globalSel == 1 && localSel == 0) {
            select.SetActive(false);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Debug.Log("Only one tile can be selected.");
        }
    }
}
