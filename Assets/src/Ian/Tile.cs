using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    public int indX;
    public int indY;

    [SerializeField] public GameObject highlight;
    [SerializeField] public GameObject select;
    
    public virtual void OnMouseEnter() {
        highlight.SetActive(true);
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public virtual void OnMouseExit() {
        highlight.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    public virtual void OnMouseDown() {
        var GM = GameObject.Find("GridManager");
        GM.SendMessage("SetTile", this.gameObject);
    }
}
