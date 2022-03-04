using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileThumb : MonoBehaviour
{
    [SerializeField] private GameObject Tile;
    [SerializeField] private Transform thumbPos;

    private GameObject draggedTileThumb;

    void OnMouseDown() {
        draggedTileThumb = Instantiate(Tile, thumbPos.position, Quaternion.identity, thumbPos);
    }

    void OnMouseDrag() {
        draggedTileThumb.transform.position = GetMousePos();
    }

    void OnMouseUp() {
        Destroy(draggedTileThumb);
    }
    
    Vector3 GetMousePos() {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
