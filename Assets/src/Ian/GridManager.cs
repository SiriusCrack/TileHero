using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [SerializeField] public int width, height;
    [SerializeField] public float tileSize;
    [SerializeField] public GameObject dTile; // Default Tile
    [SerializeField] public GameObject sTile; // Start Tile
    [SerializeField] public GameObject eTile; // End Tile
    private GameObject startTile;
    private GameObject endTile;
    private int finX, finY;
    [SerializeField] public Transform mainCamera;
    [SerializeField] public GameObject tileInventory;
    [SerializeField] public GameObject tileFactory;
    public Dictionary<(int, int), GameObject> GridStorage;
    [SerializeField] public List<((int, int), GameObject)> Path;


    void Start() {
        initGrid();
    }

    public void initGrid() {
        GridStorage = new Dictionary<(int, int), GameObject>();
        Path = new List<((int, int), GameObject)>();
        for( int x = 0; x < width; x++) {
            for( int y = 0; y < height; y++) {

                if ( x == 0 && y == 0 ) {
                    startTile = Instantiate(sTile, new Vector3(x,y), Quaternion.identity);
                    startTile.transform.parent = GameObject.Find("GridManager").transform;
                    startTile.name = $"ST[{x}][{y}]";
                    startTile.transform.position = new Vector2(x*tileSize,y*tileSize);

                    GridStorage[(x, y)] = startTile;
                    Path.Add(((0, 0), startTile));
                    Debug.Log(Path[0]);
                }
                else if ( x == width-1 && y == height-1 ) {
                    endTile = Instantiate(eTile, new Vector3(x,y), Quaternion.identity);
                    endTile.transform.parent = GameObject.Find("GridManager").transform;
                    endTile.name = $"ET[{x}][{y}]";
                    endTile.transform.position = new Vector2(x*tileSize,y*tileSize);

                    GridStorage[(x, y)] = endTile;                    
                    finX = x;
                    finY = y;
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

    public void SetDirection(int nextX, int nextY, int exit, GameObject nextTile) {
        var lastList = Path.Last();
        GameObject prevTile = lastList.Item2;
        Path.Add(((nextX, nextY), nextTile));
        prevTile.GetComponent<levelTile>().SetExit(exit);
        Debug.Log($"Added {nextTile}: {nextX}, {nextY}");
    }

    public void Update() {
        if(Input.GetKeyDown("space")) {
            int lasX = Path.Last().Item1.Item1;
            int lasY = Path.Last().Item1.Item2;
            if(lasX == finX-1) {
                SetDirection(finX, finY, 1, endTile);
            }
            if(lasY == finY-1) {
                SetDirection(finX, finY, 2, endTile);
            }
        }
    }
}