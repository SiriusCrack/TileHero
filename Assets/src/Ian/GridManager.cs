using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    [SerializeField] public int width, height;
    [SerializeField] public float tileSize;
    [SerializeField] private TileSlot emptyTile, startTile, endTile;
    [SerializeField] private Transform mainCamera;

    public Dictionary<Vector2, string> GridStorage;

    void Start() {
        initGrid();
    }

    void initGrid() {
        GridStorage = new Dictionary<Vector2, string>();
        for( int x = 0; x < width; x++) {
            for( int y = 0; y < height; y++) {
                var spawnedTile = Instantiate(emptyTile, new Vector3(x,y), Quaternion.identity);
                spawnedTile.transform.parent = GameObject.Find("GridManager").transform;
                spawnedTile.name = $"T[{x}][{y}]";
                spawnedTile.transform.position = new Vector2(x*tileSize,y*tileSize);

                GridStorage[new Vector2(x,y)] = spawnedTile.name;
            }
        }

        mainCamera.transform.position = new Vector3(((float)width*tileSize)/2 - 0.5f, ((float)height*tileSize)/2 - 0.5f, -10);
    }
}
