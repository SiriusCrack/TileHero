using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stress : MonoBehaviour
{
    [SerializeField] tileFactory tileFactory;
    private float x = -1.5f;
    private float y = 4.7f;
    private float width = 8f;
    //private float height = -0.03f;
    private int tile;

    void Update()
    {
        var spawnedTile = tileFactory.GetNewTile(tile);
        spawnedTile.name = $"{x},{y}";
        spawnedTile.transform.position = new Vector2(x,y);
        if(x > width) {
            x = -1.5f;
        }
        tile++;
        tile = tile%3;
        x += 0.01f;
        y -= 0.0001f;
    }
}
