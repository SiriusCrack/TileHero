using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [SerializeField] public int width, height;
    [SerializeField] public float tileSize;
    [SerializeField] public GameObject dTile; // Default Tile
    [SerializeField] public GameObject sTile; // Start Tile
    [SerializeField] public GameObject eTile; // End Tile
    [SerializeField] public Transform mainCamera;
    [SerializeField] public GameObject tileInventory;
    [SerializeField] public GameObject tileFactory;

    public Dictionary<(int, int), GameObject> GridStorage;

    void Start() {
        initGrid();
    }

    public void initGrid() {
        GridStorage = new Dictionary<(int, int), GameObject>();
        for( int x = 0; x < width; x++) {
            for( int y = 0; y < height; y++) {

                if ( x == 0 && y == 0 ) {
                    var startTile = Instantiate(sTile, new Vector3(x,y), Quaternion.identity);
                    startTile.transform.parent = GameObject.Find("GridManager").transform;
                    startTile.name = $"ST[{x}][{y}]";
                    startTile.transform.position = new Vector2(x*tileSize,y*tileSize);

                    GridStorage[(x, y)] = startTile;
                }
                else if ( x == width-1 && y == height-1 ) {
                    var endTile = Instantiate(eTile, new Vector3(x,y), Quaternion.identity);
                    endTile.transform.parent = GameObject.Find("GridManager").transform;
                    endTile.name = $"ET[{x}][{y}]";
                    endTile.transform.position = new Vector2(x*tileSize,y*tileSize);

                    GridStorage[(x, y)] = endTile;                    
                }
                else {
                    var defaultTile = Instantiate(dTile, new Vector3(x,y), Quaternion.identity);
                    defaultTile.transform.parent = GameObject.Find("GridManager").transform;
                    defaultTile.GetComponent<EmptyTile>().indX = x;
                    defaultTile.GetComponent<EmptyTile>().indY = y;                 
                    defaultTile.name = $"T[{x}][{y}]";
                    defaultTile.transform.position = new Vector2(x*tileSize,y*tileSize);

                    GridStorage[(x,y)] = defaultTile;   
                }
            }
        }
        mainCamera.transform.position = new Vector3(((float)width*tileSize)/2 - 0.5f, ((float)height*tileSize)/2 - 0.5f, -10);
    }

    public void SetTile(GameObject Tile) {
        var x = Tile.GetComponent<EmptyTile>().indX;
        var y = Tile.GetComponent<EmptyTile>().indY;
        var levelTile = tileFactory.GetComponent<tileFactory>().GetNewTile (tileInventory.GetComponent<tileInventory>().SelectedTile);
        var prevTileSlot = GridStorage[(x,y)];
        levelTile.transform.parent = GameObject.Find("GridManager").transform;
        levelTile.GetComponent<levelTile>().indX = x;
        levelTile.GetComponent<levelTile>().indY = y;
        levelTile.name = $"LT[{x}][{y}]";
        levelTile.transform.position = prevTileSlot.transform.position;
        Destroy(GridStorage[(x,y)]);
        GridStorage[(x,y)] = levelTile;

    }
}
