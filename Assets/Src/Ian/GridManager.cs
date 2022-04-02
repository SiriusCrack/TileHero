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

    [SerializeField] public List<((int, int), GameObject)> path;
    public Dictionary<(int, int), GameObject> gridStorage;

    private GameObject startTile;
    private GameObject endTile;
    private int finX, finY;

    void Start()
    {
        initGrid();
    }

    public void initGrid()
    {
        gridStorage = new Dictionary<(int, int), GameObject>();
        path = new List<((int, int), GameObject)>();
        for( int x = 0; x < width; x++) {
            for( int y = 0; y < height; y++) {

                if ( x == 0 && y == 0 ) {
                    startTile = Instantiate(sTile, new Vector3(x,y), Quaternion.identity);
                    startTile.transform.parent = GameObject.Find("GridManager").transform;
                    startTile.name = $"ST[{x}][{y}]";
                    startTile.transform.position = new Vector3(x*tileSize,y*tileSize,0);
            
                    gridStorage[(x, y)] = startTile;
                    path.Add(((0, 0), startTile));
                }
                else if ( x == width-1 && y == height-1 ) {
                    endTile = Instantiate(eTile, new Vector3(x,y), Quaternion.identity);
                    endTile.transform.parent = GameObject.Find("GridManager").transform;
                    endTile.name = $"ET[{x}][{y}]";
                    endTile.transform.position = new Vector3(x*tileSize,y*tileSize,0);

                    gridStorage[(x, y)] = endTile;                    
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

                    gridStorage[(x,y)] = defaultTile;   
                }
            }
        }
        mainCamera.transform.position = new Vector3(((float)width*tileSize)/2 - 0.5f, ((float)height*tileSize)/2 - 0.5f, -10);
        if( width > 5 || height > 5)
        {
            mainCamera.gameObject.GetComponent<Camera>().orthographicSize = 3.5f;
        }
        else {
            mainCamera.gameObject.GetComponent<Camera>().orthographicSize = 3;
        }
    }

    public void SetTile(GameObject tile)
    {
        // Current index of selected tile.
        var x = tile.GetComponent<EmptyTile>().indX;
        var y = tile.GetComponent<EmptyTile>().indY;
        
        // Stores the selected tile type.
        var tileTypeCheck = tileInventory.GetComponent<TileInventory>().selectedTile;

        // Check if no tile type has been selected.
        if( tileTypeCheck == null ) {
            Debug.Log("SetTile() :: ERROR! No tile type selected!");
            return;
        }
        // If there is a valid tile type.
        else if ( tileTypeCheck != null ) {

            var prevTile = path.Last().Item2;
            int prevTileX = path.Last().Item1.Item1;
            int prevTileY = path.Last().Item1.Item2;
            Debug.Log($"SetTile() :: Selected Tile: \"{tile.name}\", Index: [{x}][{y}]");
            Debug.Log($"SetTile() :: Previous Tile: \"{prevTile.name}\", Index: [{prevTileX}][{prevTileY}]");

            // Check if previous tile is the "Start".
            if( prevTile.tag == "Start" )
            {
                Transform child; 
                int exitStart = prevTile.GetComponent<StartTile>().exit; // Get exit direction of "Start".
                // If the previous x equals the current x.
                if ( prevTileX == x ) {
                    // If current tile is above the "Start".
                    if ( prevTileY == y - 1 ) {
                        Debug.Log("Selected Tile is above \"Start\"");
                        if( exitStart == -1 ) {
                            InitTile(tile);
                            prevTile.GetComponent<StartTile>().exit = 0;    // Set exit variable to direction.
                            child = prevTile.gameObject.transform.Find("NorthDoor"); // Get the door child object.
                            child.gameObject.SetActive(true); // Activate child object.
                        }
                    }
                    // If current tile is below the "Start".
                    else if ( prevTileY == y + 1) {
                        Debug.Log("Selected Tile is below \"Start\"");
                        if( exitStart == -1 ) {
                            InitTile(tile);
                            prevTile.GetComponent<StartTile>().exit = 2;
                            child = prevTile.gameObject.transform.Find("SouthDoor");
                            child.gameObject.SetActive(true);
                        }
                    }
                }
                // If the previous y equals the current y.
                else if ( prevTileY == y ) {
                    // If current tile is right of the "Start".
                    if ( prevTileX == x - 1 ) {
                        Debug.Log("Selected Tile is right of \"Start\"");
                        if( exitStart == -1 ) {
                            InitTile(tile);
                            prevTile.GetComponent<StartTile>().exit = 1;
                            child = prevTile.gameObject.transform.Find("EastDoor");
                            child.gameObject.SetActive(true);
                        }
                    }
                    // If current tile is left of the "Start".
                    else if ( prevTileX == x + 1 ) {
                        Debug.Log("Selected Tile is left of \"Start\"");
                        if( exitStart == -1 ) {
                            InitTile(tile);
                            prevTile.GetComponent<StartTile>().exit = 3;
                            child = prevTile.gameObject.transform.Find("WestDoor");
                            child.gameObject.SetActive(true);
                        }
                    }
                }
            }
            // Check if previous tile is a "LevelTile".
            else if( prevTile.tag == "LevelTile" )
            {
                Transform child;
                // If the previous x equals the current x.
                if ( prevTileX == x ) {
                    // If current tile is above a "LevelTile".
                    if ( prevTileY == y - 1 ) {
                        Debug.Log("Selected Tile is above \"LevelTile\"");
                        child = prevTile.gameObject.transform.Find("NorthDoor");
                        if( !(child.gameObject.activeSelf) ) {
                            Debug.Log("Invalid placement.");
                        }
                        else {
                            InitTile(tile);
                        }
                    }
                    // If current tile is below a "LevelTile".
                    else if ( prevTileY == y + 1) {
                        Debug.Log("Selected Tile is below \"LevelTile\"");
                        child = prevTile.gameObject.transform.Find("SouthDoor");
                        if( !(child.gameObject.activeSelf) ) {
                            Debug.Log("Invalid placement.");
                        }
                        else {
                            InitTile(tile);
                        }
                    }
                }
                // If the previous y equals the current y.
                else if ( prevTileY == y ) {
                    // If current tile is right of a "LevelTile".
                    if ( prevTileX == x - 1 ) {
                        Debug.Log("Selected Tile is right of \"LevelTile\"");
                        child = prevTile.gameObject.transform.Find("EastDoor");
                        if( !(child.gameObject.activeSelf) ) {
                            Debug.Log("Invalid placement.");
                        }
                        else {
                            InitTile(tile);
                        }
                    }
                    // If current tile is left of a "LevelTile".
                    else if ( prevTileX == x + 1 ) {
                        Debug.Log("Selected Tile is left of \"LevelTile\"");
                        child = prevTile.gameObject.transform.Find("WestDoor");
                        if( !(child.gameObject.activeSelf) ) {
                            Debug.Log("Invalid placement.");
                        }
                        else {
                            InitTile(tile);
                        }
                    }
                }
            }
            else {
                Debug.Log("Invalid placement.");
            }
        }
    }

    public void InitTile(GameObject tile)
    {
        // CREATES THE LEVEL TILE AND ADD TO GRID STORAGE (INITIALIZES TILE PLACEMENT)
        // Current index of selected tile.
        var x = tile.GetComponent<EmptyTile>().indX;
        var y = tile.GetComponent<EmptyTile>().indY;
        var levelTile = tileFactory.GetComponent<TileFactory>().GetNewTile (tileInventory.GetComponent<TileInventory>().selectedTile); // Get the particular tile type for the designated location.
        var prevTileSlot = gridStorage[(x,y)]; // Return the current tile game object from Grid Storage.
        levelTile.transform.parent = GameObject.Find("GridManager").transform; // Designate this new level as a child to Grid Manager.
        levelTile.GetComponent<LevelTile>().indX = x; // Set the index, x.
        levelTile.GetComponent<LevelTile>().indY = y; // Set the index, y.
        levelTile.name = $"LT[{x}][{y}]"; // Name accordingly.
        levelTile.transform.position = prevTileSlot.transform.position; // Set the position of the tile to the previous.
        Destroy(gridStorage[(x,y)]); // Destroy the old tile object.
        gridStorage[(x,y)] = levelTile; // Store the level tile object in Grid Storage.
    }


    public bool SetDirection(int x, int y, int dir, GameObject nextTile)
    {
        GameObject prevTile = path.Last().Item2;

        // Check if door placement is out of bounds.
        if ( dir == 0 ) {
            if ( y + 1 >= height ) {
                Debug.Log("Cannot place a door out of bounds!");
                return false;
            }
        }
        if ( dir == 1 ) {
            if( x + 1 >= width ) {
                Debug.Log("Cannot place a door out of bounds!");
                return false;
            }
        }
        if ( dir == 2 ) {
            if ( y - 1 < 0 ) {
                Debug.Log("Cannot place a door out of bounds!");
                return false;
            }
        }
        if ( dir == 3)  {
            if ( x - 1 < 0 ) {
                Debug.Log("Cannot place a door out of bounds!");
                return false;
            }
        }

        // Check if current tile's door direction collides with its previous adjacent tile's.
        if ( prevTile.tag == "Start" ) {
            if( x == 1 && y == 0) {
                if (dir == 3) {
                    Debug.Log("An east door from this tile should not be placed.");
                    return false;
                }
            }
            else if ( x == 0 && y == 1) {
                if (dir == 0) {
                    Debug.Log("A south door from this tile should not be placed.");
                    return false;
                }
            }
        }
        else if ( prevTile.tag == "LevelTile") {
            Transform child;
            int prevTileX = prevTile.GetComponent<LevelTile>().indX;
            int prevTileY = prevTile.GetComponent<LevelTile>().indY;

            if ( prevTileX == x ) {
                // If current tile is above a "LevelTile".
                if ( prevTileY == y - 1 ) {
                    //Debug.Log("Selected Tile is above \"LevelTile\"");
                    if( dir == 2 ) {
                        child = prevTile.gameObject.transform.Find("NorthDoor");
                        if( child.gameObject.activeSelf ) {
                            Debug.Log("Invalid door placement.");
                            return false;
                        }
                    }
                }
                // If current tile is below a "LevelTile".
                else if ( prevTileY == y + 1) {
                    //Debug.Log("Selected Tile is below \"LevelTile\"");
                    if( dir == 0 ) {
                        child = prevTile.gameObject.transform.Find("SouthDoor");
                        if( child.gameObject.activeSelf ) {
                            Debug.Log("Invalid door placement.");
                            return false;
                        }
                    }
                }
            }
            // If the previous y equals the current y.
            else if ( prevTileY == y ) {
                // If current tile is right of a "LevelTile".
                if ( prevTileX == x - 1 ) {
                    //Debug.Log("Selected Tile is right of \"LevelTile\"");
                    if( dir == 3 ) {
                        child = prevTile.gameObject.transform.Find("EastDoor");
                        if( child.gameObject.activeSelf ) {
                            Debug.Log("Invalid door placement.");
                            return false;
                        }
                    }
                }
                // If current tile is left of a "LevelTile".
                else if ( prevTileX == x + 1 ) {
                    //Debug.Log("Selected Tile is left of \"LevelTile\"");
                    if( dir == 1 ) {
                        child = prevTile.gameObject.transform.Find("WestDoor");
                        if( child.gameObject.activeSelf ) {
                            Debug.Log("Invalid door placement.");
                            return false;
                        }
                    }
                }
            }
        }
        nextTile.GetComponent<LevelTile>().SetExit(dir);
        path.Add(((x, y), nextTile));
        Debug.Log($"Added \"{nextTile.name}\" to the path List.");
        return true;
    }
}