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
    [SerializeField] public Transform mainCamera;
    [SerializeField] public GameObject tileInventory;
    [SerializeField] public GameObject tileFactory;

    [SerializeField] public List<((int, int), GameObject)> Path;
    public Dictionary<(int, int), GameObject> GridStorage;

    private GameObject startTile;
    private GameObject endTile;
    private int finX, finY;


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
                }
                else if ( x == width-1 && y == height-1 ) {
                    endTile = Instantiate(eTile, new Vector3(x,y), Quaternion.identity);
                    endTile.transform.parent = GameObject.Find("GridManager").transform;
                    endTile.name = $"ET[{x}][{y}]";
                    endTile.transform.position = new Vector3(x*tileSize,y*tileSize,1);

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
        GameObject prevTile = Path.Last().Item2;
        if ( prevTile.tag != "Start" ) {
            var exit = prevTile.GetComponent<levelTile>().exit;
            int prevX = Path.Last().Item1.Item1;
            int prevY = Path.Last().Item1.Item2;
            if(exit == 0) {
                if (x != prevX || y != prevY+1) {
                    return;
                }
            }
            if(exit == 1) {
                if (y != prevY || x != prevX+1) {
                    return;
                }
            }
            if(exit == 2) {
                if (x != prevX || y != prevY-1) {
                    return;
                }
            }
            if(exit == 3) {
                if (y != prevY || x != prevX-1) {
                    return;
                }
            }
        }
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

    public bool SetDirection(int nextX, int nextY, int dir, GameObject nextTile) {
        GameObject prevTile = Path.Last().Item2;

        if ( prevTile.tag == "Start" ) {
            Transform child;
            if( nextX == 1 && nextY == 0) {
                if (dir == 3) {
                    Debug.Log("An east door from this tile should not be placed.");
                }
                child = prevTile.gameObject.transform.Find("EastDoor");
                child.gameObject.SetActive(true);
            }
            else if ( nextX == 0 && nextY == 1) {
                if (dir == 0) {
                    Debug.Log("A south door from this tile should not be placed.");
                }
                child = prevTile.gameObject.transform.Find("NorthDoor");
                child.gameObject.SetActive(true);
            }
        }
        if ( prevTile.tag == "LevelTile") {
            Transform child;
            int badX = prevTile.GetComponent<levelTile>().indX;
            int badY = prevTile.GetComponent<levelTile>().indY;

            // For previous Tiles above and below this Tile
            if( badX == nextX ) {
                // If previous Tile is above to this Tile
                if( badY == (nextY + 1) ) {
                    Debug.Log("The previous tile is above this tile.");
                    if( dir == 0 ) {
                        child = prevTile.gameObject.transform.Find("SouthDoor");
                        if( child.gameObject.activeSelf ) {
                            Debug.Log("A north door from this tile should not be placed.");
                            return false;
                        }
                    }
                }
                // If previous Tile is below to this Tile
                else if( badY == (nextY - 1) ) {
                    Debug.Log("The previous tile is below this tile.");
                    if( dir == 2 ) {
                        child = prevTile.gameObject.transform.Find("NorthDoor");
                        if( child.gameObject.activeSelf ) {
                            Debug.Log("A south door from this tile should not be placed.");
                            return false;
                        }
                    }
                }
            }
            // For previous Tiles to the right and left of this Tile
            else if ( badY == nextY ) {
                // If previous Tile is right to this Tile
                if( badX == (nextX + 1) ) {
                    Debug.Log("The previous tile is to the right of this tile.");
                    if( dir == 1 ) {
                        child = prevTile.gameObject.transform.Find("WestDoor");
                        if( child.gameObject.activeSelf ) {
                            Debug.Log("An east door from this tile should not be placed.");
                            return false;
                        }
                    }
                }
                // If previous Tile is left to this Tile
                else if( badX == (nextX - 1) ) {
                    Debug.Log("The previous tile is to the left of this tile.");
                    if( dir == 3 ) {
                        child = prevTile.gameObject.transform.Find("EastDoor");
                        if( child.gameObject.activeSelf ) {
                            Debug.Log("A west door from this tile should not be placed.");
                            return false;
                        }
                    }
                }
            }
        }

        nextTile.GetComponent<levelTile>().SetExit(dir);
        Path.Add(((nextX, nextY), nextTile));
        Debug.Log($"Added {nextTile}: {nextX}, {nextY}");
        return true;
    }
}