using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInventory : MonoBehaviour
{
    public GameObject selectedTile = null;
    [SerializeField] private GameObject tileTypeA, tileTypeB;
    [SerializeField] private GameObject thumbA, thumbB;
    public bool globalSelect = false;


    void PickTile(GameObject selectedThumb)
    {
        if (selectedThumb == thumbA) {
            selectedTile = tileTypeA;
        }
        if (selectedThumb == thumbB) {
            selectedTile = tileTypeB;
        }
    }
}