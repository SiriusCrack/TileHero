using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileThumb : MonoBehaviour {
    tileInventory tileInventory;

    void Start() {
        tileInventory = GetComponentInParent<tileInventory>();

    }

    void OnMouseDown() {
        tileInventory = GetComponentInParent<tileInventory>();
        Debug.Log(tileInventory.SelectedTile);
        tileInventory.SelectedTile = this.gameObject;
    }
}