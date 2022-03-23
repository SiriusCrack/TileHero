using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileInventory : MonoBehaviour
{
    public levelTile SelectedTile;
    [SerializeField] levelTile TileType1, TileType2;
    [SerializeField] GameObject thumb1, thumb2;

    void PickTile(GameObject selectedThumb) {
            if (selectedThumb == thumb1) {
                SelectedTile = TileType1;
            }
            if (selectedThumb == thumb2) {
                SelectedTile = TileType2;
            }

            
        }
}
