using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tileThumb : MonoBehaviour, IPointerEnterHandler {
    tileInventory tileInventory;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    bool localSelect = false;

    void Start() {
        tileInventory = GetComponentInParent<tileInventory>();

        // Button tileButton = this.gameObject.GetComponent<Button>();
        // tileButton.onClick.AddListener(TaskOnClick);
    }

    void Update() {
    }

    public void OnPointerEnter(PointerEventData eventData) {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
    public void OnPointerExit(PointerEventData eventData) {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }


    public void SelectTile() {
        tileInventory = GetComponentInParent<tileInventory>();

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