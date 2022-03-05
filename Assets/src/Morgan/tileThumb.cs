using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileThumb : MonoBehaviour
{
    public Vector3 dropPos; //Should be able to take this and check position relative to valid grid space

    private GameObject draggedTileThumb;

    void OnMouseDown() {
        draggedTileThumb = Instantiate(gameObject, gameObject.transform.position, Quaternion.identity, gameObject.transform);
    }

    void OnMouseDrag() {
        draggedTileThumb.transform.position = GetMousePos();
    }

    void OnMouseUp() {
        dropPos = Input.mousePosition;
        Debug.Log(dropPos.x);
        Debug.Log(dropPos.y);
        Destroy(draggedTileThumb);
    }
    
    Vector3 GetMousePos() {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
