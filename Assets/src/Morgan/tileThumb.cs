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
        tileInventory.SelectedTile = this.gameObject;
        Debug.Log(tileInventory.SelectedTile);
    }
}