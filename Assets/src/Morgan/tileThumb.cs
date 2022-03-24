using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileThumb : MonoBehaviour {
    tileInventory tileInventory;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    [SerializeField] public GameObject highlight;
    [SerializeField] public GameObject select;
    bool localSelect = false;

    void Start() {
        tileInventory = GetComponentInParent<tileInventory>();

    }

    //Highlight
    void OnMouseEnter() {
        highlight.SetActive(true);
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    void OnMouseExit() {
        highlight.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    /*void Update() {
        Debug.Log(this.gameObject);
        if (GetComponentInParent<tileInventory>().SelectedTile == this.gameObject) {
            select.SetActive(true);
        }
    }*/

    void OnMouseDown() {
        tileInventory = GetComponentInParent<tileInventory>();

        if (tileInventory.globalSelect == false && localSelect == false) {
            tileInventory.globalSelect = true;
            localSelect = true;
            select.SetActive(true);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Debug.Log(this.gameObject.name + " selected.");
            tileInventory.SendMessage("PickTile", this.gameObject);
        }
        else if (tileInventory.globalSelect == true && localSelect == true) {
            tileInventory.globalSelect = false;
            localSelect = false;
            select.SetActive(false);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Debug.Log(this.gameObject.name + " deselected.");
            tileInventory.SendMessage("PickTile", this.gameObject);
        }
        else if (tileInventory.globalSelect == true && localSelect == false) {
            select.SetActive(false);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            Debug.Log("Only one tile type can be selected.");
        }
    }
}