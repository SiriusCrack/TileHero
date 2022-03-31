using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileInventory : MonoBehaviour
{
    public GameObject SelectedTile = null;
    [SerializeField] private GameObject TileType1, TileType2;
    [SerializeField] private GameObject thumb1, thumb2;
    public bool globalSelect = false;

    void PickTile(GameObject selectedThumb) {
        if (selectedThumb == thumb1) {
            SelectedTile = TileType1;
        }
        if (selectedThumb == thumb2) {
            SelectedTile = TileType2;
        }
    }
}
