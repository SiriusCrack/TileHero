/*
 * Filename: DemoGridManager.cs
 * Developer: Ian Fleming
 * Purpose: This script is is a copy of the Grid Manager with implementations to assist in the Demo presentation.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * Summary: DemoGridManager class contains all code implementations to initialize and populate the grid system.
 * 
 * Member Variables:
 * width - Width of the grid
 * height - Height of the grid
 * tileSize - Value to add tile padding/separation
 * dTile - Game object placeholder for the default tile
 * sTile - Game object placeholder for the start tile
 * eTile - Game object placeholder for the end tile
 * oTile - Game object placeholder for the obstacle tile
 * mainCamera - Game object for the camera of the scene
 * tileInventory - Game object for the tile inventory system
 * tileFactory - Game object for the tile factory system
 * validPath - List of the tiles that create a valid path from start to end
 * gridStorage - Dictionary of all the tiles initialized into the game 
 * startTile - Game object placeholder of the start tile
 * endTile - Game object placeholder of the end tile
 * obstacleTile - Game object placeholder of the obstacle tile
 * finX - X index of the end tile
 * finY - Y index of the end tile
 */
public class DemoGridManager : MonoBehaviour {
    [SerializeField] public int width, height;
    [SerializeField] public float tileSize;
    [SerializeField] public GameObject dTile; 
    [SerializeField] public GameObject sTile; 
    [SerializeField] public GameObject eTile;
    [SerializeField] public GameObject oTile;
    [SerializeField] public Transform mainCamera;
    [SerializeField] public GameObject tileInventory;
    [SerializeField] public GameObject tileFactory;

    public List<((int, int), GameObject)> validPath;
    public Dictionary<(int, int), GameObject> gridStorage;

    private GameObject startTile;
    private GameObject endTile;
    private GameObject obstacleTile;
    private int finX, finY;

    [SerializeField] GameObject demoTile;

    /*
     * Summary: Function call at object creation/game start. Calls the InitGrid().
     *
     * Parameters: None
     *
     * Returns: None
    */
    void Start() 
    {
        InitGrid();
        DemoPopulateGrid();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        gridStorage[(0,0)].GetComponent<StartTile>().exit = 1;
    }


    /*
     * Summary: Initializes the grid system.
     *
     * Parameters: None
     *
     * Returns: None
    */
    public void InitGrid() 
    {
        gridStorage = new Dictionary<(int, int), GameObject>();
        validPath = new List<((int, int), GameObject)>();
        for ( int x = 0; x < width; x++ ) {
            for ( int y = 0; y < height; y++ ) {

                if ( x == 0 && y == 0 ) {
                    startTile = Instantiate(sTile, new Vector3(x,y), Quaternion.identity);
                    startTile.transform.parent = GameObject.Find("GridManager").transform;
                    startTile.name = $"ST[{x}][{y}]";
                    startTile.transform.position = new Vector3(x*tileSize,y*tileSize,0);
            
                    gridStorage[(x, y)] = startTile;
                    validPath.Add(((0, 0), startTile));
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
                else if ( x == (width-1)/2 && y == (height-1)/2 ) {
                    obstacleTile = Instantiate(oTile, new Vector3(x,y), Quaternion.identity);
                    obstacleTile.transform.parent = GameObject.Find("GridManager").transform;
                    obstacleTile.name = $"OT[{x}{y}]";
                    obstacleTile.transform.position = new Vector3(x*tileSize,y*tileSize,0);

                    gridStorage[(x, y)] = obstacleTile;
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
        if ( width > 5 || height > 5 )
        {
            mainCamera.gameObject.GetComponent<Camera>().orthographicSize = 3.5f;
        }
        else {
            mainCamera.gameObject.GetComponent<Camera>().orthographicSize = 3;
        }
    }


    /*
     * Summary: Checks if the tile placement is valid at the designated location.
     *
     * Parameters:
     * Tile - The tile type game object to be placed 
     *
     * Returns: None
    */
    public void SetTile(GameObject Tile) 
    {
        // Current index of selected tile.
        var x = Tile.GetComponent<EmptyTile>().indX;
        var y = Tile.GetComponent<EmptyTile>().indY;
        
        // Stores the selected tile type.
        var TileTypeCheck = tileInventory.GetComponent<TileInventory>().selectedTile;

        // Check if no tile type has been selected.
        if ( TileTypeCheck == null ) {
            Debug.Log("SetTile() :: ERROR! No tile type selected!");
            return;
        }
        // If there is a valid tile type.
        else if ( TileTypeCheck != null ) {

            var prevTile = validPath.Last().Item2;
            int prevTileX = validPath.Last().Item1.Item1;
            int prevTileY = validPath.Last().Item1.Item2;
            Debug.Log($"SetTile() :: Selected Tile: \"{Tile.name}\", Index: [{x}][{y}]");
            Debug.Log($"SetTile() :: Previous Tile: \"{prevTile.name}\", Index: [{prevTileX}][{prevTileY}]");

            // Check if previous tile is the "Start".
            if ( prevTile.tag == "Start" )
            {
                Transform child; 
                int exitStart = prevTile.GetComponent<StartTile>().exit; // Get exit direction of "Start".
                // If the previous x equals the current x.
                if ( prevTileX == x ) {
                    // If current tile is above the "Start".
                    if ( prevTileY == y - 1 ) {
                        Debug.Log("Selected Tile is above \"Start\"");
                        if( exitStart == -1 ) {
                            InitTile(Tile);
                            prevTile.GetComponent<StartTile>().exit = 0;    // Set exit variable to direction.
                            child = prevTile.gameObject.transform.Find("NorthDoor"); // Get the door child object.
                            child.gameObject.SetActive(true); // Activate child object.
                        }
                    }
                    // If current tile is below the "Start".
                    else if ( prevTileY == y + 1) {
                        Debug.Log("Selected Tile is below \"Start\"");
                        if ( exitStart == -1 ) {
                            InitTile(Tile);
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
                        if ( exitStart == -1 ) {
                            InitTile(Tile);
                            prevTile.GetComponent<StartTile>().exit = 1;
                            child = prevTile.gameObject.transform.Find("EastDoor");
                            child.gameObject.SetActive(true);
                        }
                    }
                    // If current tile is left of the "Start".
                    else if ( prevTileX == x + 1 ) {
                        Debug.Log("Selected Tile is left of \"Start\"");
                        if ( exitStart == -1 ) {
                            InitTile(Tile);
                            prevTile.GetComponent<StartTile>().exit = 3;
                            child = prevTile.gameObject.transform.Find("WestDoor");
                            child.gameObject.SetActive(true);
                        }
                    }
                }
            }
            // Check if previous tile is a "LevelTile".
            else if ( prevTile.tag == "LevelTile" )
            {
                Transform child;
                // If the previous x equals the current x.
                if ( prevTileX == x ) {
                    // If current tile is above a "LevelTile".
                    if ( prevTileY == y - 1 ) {
                        Debug.Log("Selected Tile is above \"LevelTile\"");
                        child = prevTile.gameObject.transform.Find("NorthDoor");
                        if ( !(child.gameObject.activeSelf) ) {
                            Debug.Log("Invalid placement.");
                        }
                        else {
                            InitTile(Tile);
                        }
                    }
                    // If current tile is below a "LevelTile".
                    else if ( prevTileY == y + 1) {
                        Debug.Log("Selected Tile is below \"LevelTile\"");
                        child = prevTile.gameObject.transform.Find("SouthDoor");
                        if ( !(child.gameObject.activeSelf) ) {
                            Debug.Log("Invalid placement.");
                        }
                        else {
                            InitTile(Tile);
                        }
                    }
                }
                // If the previous y equals the current y.
                else if ( prevTileY == y ) {
                    // If current tile is right of a "LevelTile".
                    if ( prevTileX == x - 1 ) {
                        Debug.Log("Selected Tile is right of \"LevelTile\"");
                        child = prevTile.gameObject.transform.Find("EastDoor"); 
                        if ( !(child.gameObject.activeSelf) ) {
                            Debug.Log("Invalid placement.");
                        }
                        else {
                            InitTile(Tile);
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
                            InitTile(Tile);
                        }
                    }
                }
            }
            else {
                Debug.Log("Invalid placement.");
            }
        }
    }


    /*
     * Summary: Creates the level tile and adds it to the grid storage.
     *
     * Parameters:
     * Tile - The tile type game object to be placed 
     *
     * Returns: None
    */
    public void InitTile(GameObject Tile) 
    {
        // Current index of selected tile.
        var x = Tile.GetComponent<EmptyTile>().indX;
        var y = Tile.GetComponent<EmptyTile>().indY;
        // Get the particular tile type for the designated location.
        var levelTile = tileFactory.GetComponent<TileFactory>().GetNewTile (tileInventory.GetComponent<TileInventory>().selectedTile); 
        // Return the current tile game object from Grid Storage.
        var prevTileSlot = gridStorage[(x,y)]; 
        // Designate this new level as a child to Grid Manager.
        levelTile.transform.parent = GameObject.Find("GridManager").transform; 
        // Set the index, x.
        levelTile.GetComponent<LevelTile>().indX = x;
        // Set the index, y.
        levelTile.GetComponent<LevelTile>().indY = y; 
        // Name accordingly.
        levelTile.name = $"LT[{x}][{y}]";
        // Set the position of the tile to the previous.
        levelTile.transform.position = prevTileSlot.transform.position;
        // Destroy the old tile object.
        Destroy(gridStorage[(x,y)]); 
        // Store the level tile object in Grid Storage.
        gridStorage[(x,y)] = levelTile; 
    }


     /*
     * Summary: Determines if the door placement of the tile is valid.
     *
     * Parameters:
     * x - X index of the placed tile
     * y - Y index of the place tile
     * dir - integer value of the door direction
     * nextTile - Game object place holder of the tile that will have its door placed
     *
     * Returns:
     * Boolian - Returns true is the direction of the door is valid, returns false if not valid
    */
    public bool SetDirection(int x, int y, int dir, GameObject nextTile) 
    {
        GameObject prevTile = validPath.Last().Item2;
        GameObject connectingTile;

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

        // Prevents connecting to an obstacle and path looping
        if ( dir == 0 )
        {
           connectingTile = gridStorage[(x, y+1)];
            if( connectingTile.tag == "Start" && connectingTile.GetComponent<StartTile>().exit != -1) {
                Debug.Log("Can't connect to Start.");
                return false;
            }
            else if ( connectingTile.tag == "LevelTile" && connectingTile.GetComponent<LevelTile>().connected == true) {
                Debug.Log("Can't connect to a tile already connected.");
                return false;
            }
            else if ( connectingTile.tag == "Obstacle" ) {
                Debug.Log("Can't connect to an obstacle.");
                return false;
            }
        }
        else if ( dir == 1 ) {
            connectingTile = gridStorage[(x+1, y)];
            if( connectingTile.tag == "Start" && connectingTile.GetComponent<StartTile>().exit != -1) {
                Debug.Log("Can't connect to Start.");
                return false;
            }
            else if ( connectingTile.tag == "LevelTile" && connectingTile.GetComponent<LevelTile>().connected == true) {
                Debug.Log("Can't connect to a tile already connected.");
                return false;
            }
            else if ( connectingTile.tag == "Obstacle" ) {
                Debug.Log("Can't connect to an obstacle.");
                return false;
            }            
        }
        else if ( dir == 2 ) {
            connectingTile = gridStorage[(x, y-1)];
            if( connectingTile.tag == "Start" && connectingTile.GetComponent<StartTile>().exit != -1) {
                Debug.Log("Can't connect to Start.");
                return false;
            }
            else if ( connectingTile.tag == "LevelTile" && connectingTile.GetComponent<LevelTile>().connected == true) {
                Debug.Log("Can't connect to a tile already connected.");
                return false;
            }
            else if ( connectingTile.tag == "Obstacle" ) {
                Debug.Log("Can't connect to an obstacle.");
                return false;
            }
        }
        else if ( dir == 3 ) {
           connectingTile = gridStorage[(x-1, y)];
            if( connectingTile.tag == "Start" && connectingTile.GetComponent<StartTile>().exit != -1) {
                Debug.Log("Can't connect to Start.");
                return false;
            }
            else if ( connectingTile.tag == "LevelTile" && connectingTile.GetComponent<LevelTile>().connected == true) {
                Debug.Log("Can't connect to a tile already connected.");
                return false;
            }
            else if ( connectingTile.tag == "Obstacle" ) {
                Debug.Log("Can't connect to an obstacle.");
                return false;
            }
        }

        // Check if current tile's door direction collides with its previous adjacent tile's.
        if ( prevTile.tag == "Start" ) {
            if( x == 1 && y == 0) {
                if (dir == 3) {
                    Debug.Log("Cannot place a door in this direction.");
                    return false;
                }
            }
            else if ( x == 0 && y == 1) {
                if (dir == 0) {
                    Debug.Log("Cannot place a door in this direction.");
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
                    if ( dir == 2 ) {
                        child = prevTile.gameObject.transform.Find("NorthDoor");
                        if ( child.gameObject.activeSelf ) {
                            Debug.Log("Invalid door placement.");
                            return false;
                        }
                    }
                }
                // If current tile is below a "LevelTile".
                else if ( prevTileY == y + 1 ) {
                    if ( dir == 0 ) {
                        child = prevTile.gameObject.transform.Find("SouthDoor");
                        if ( child.gameObject.activeSelf ) {
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
                    if ( dir == 3 ) {
                        child = prevTile.gameObject.transform.Find("EastDoor");
                        if ( child.gameObject.activeSelf ) {
                            Debug.Log("Invalid door placement.");
                            return false;
                        }
                    }
                }
                // If current tile is left of a "LevelTile".
                else if ( prevTileX == x + 1 ) {
                    if ( dir == 1 ) {
                        child = prevTile.gameObject.transform.Find("WestDoor");
                        if ( child.gameObject.activeSelf ) {
                            Debug.Log("Invalid door placement.");
                            return false;
                        }
                    }
                }
            }
        }
        nextTile.GetComponent<LevelTile>().SetExit(dir);
        validPath.Add(((x, y), nextTile));
        Debug.Log($"Added \"{nextTile.name}\" to the Path List.");
        return true;
    }

    /*
     * Summary: Function that populates the grid tiles with tile types into a viable path for the Demo version.
     *
     * Parameters: None
     *
     * Returns: None
    */
    void DemoPopulateGrid() {

        gridStorage[(0,0)].gameObject.transform.Find("EastDoor").gameObject.SetActive(true);
        gridStorage[(0,0)].GetComponent<StartTile>().exit = 1;

        var tempTile = Instantiate(demoTile, Vector3.zero, Quaternion.identity);
        tempTile.transform.parent = GameObject.Find("GridManager").transform; 
        tempTile.name = "LT[1][0]";
        tempTile.transform.position = gridStorage[(1,0)].transform.position;
        Destroy(gridStorage[(1,0)]); 
        gridStorage[(1,0)] = tempTile;
        gridStorage[(1,0)].gameObject.transform.Find("EastDoor").gameObject.SetActive(true);
        gridStorage[(1,0)].GetComponent<LevelTile>().exit = 1;

        tempTile = Instantiate(demoTile, Vector3.zero, Quaternion.identity);
        tempTile.transform.parent = GameObject.Find("GridManager").transform; 
        tempTile.name = "LT[2][0]";
        tempTile.transform.position = gridStorage[(2,0)].transform.position;
        Destroy(gridStorage[(2,0)]); 
        gridStorage[(2,0)] = tempTile;
        gridStorage[(2,0)].gameObject.transform.Find("NorthDoor").gameObject.SetActive(true);
        gridStorage[(2,0)].GetComponent<LevelTile>().exit = 0;

        tempTile = Instantiate(demoTile, Vector3.zero, Quaternion.identity);
        tempTile.transform.parent = GameObject.Find("GridManager").transform; 
        tempTile.name = "LT[2][1]";
        tempTile.transform.position = gridStorage[(2,1)].transform.position;
        Destroy(gridStorage[(2,1)]); 
        gridStorage[(2,1)] = tempTile;
        gridStorage[(2,1)].gameObject.transform.Find("EastDoor").gameObject.SetActive(true);
        gridStorage[(2,1)].GetComponent<LevelTile>().exit = 1; 

        tempTile = Instantiate(demoTile, Vector3.zero, Quaternion.identity);
        tempTile.transform.parent = GameObject.Find("GridManager").transform; 
        tempTile.name = "LT[3][1]";
        tempTile.transform.position = gridStorage[(3,1)].transform.position;
        Destroy(gridStorage[(3,1)]); 
        gridStorage[(3,1)] = tempTile;
        gridStorage[(3,1)].gameObject.transform.Find("NorthDoor").gameObject.SetActive(true);
        gridStorage[(3,1)].GetComponent<LevelTile>().exit = 0;

        tempTile = Instantiate(demoTile, Vector3.zero, Quaternion.identity);
        tempTile.transform.parent = GameObject.Find("GridManager").transform; 
        tempTile.name = "LT[3][2]";
        tempTile.transform.position = gridStorage[(3,2)].transform.position;
        Destroy(gridStorage[(3,2)]); 
        gridStorage[(3,2)] = tempTile;
        gridStorage[(3,2)].gameObject.transform.Find("NorthDoor").gameObject.SetActive(true);
        gridStorage[(3,2)].GetComponent<LevelTile>().exit = 0; 

        tempTile = Instantiate(demoTile, Vector3.zero, Quaternion.identity);
        tempTile.transform.parent = GameObject.Find("GridManager").transform; 
        tempTile.name = "LT[3][3]";
        tempTile.transform.position = gridStorage[(3,3)].transform.position;
        Destroy(gridStorage[(3,3)]); 
        gridStorage[(3,3)] = tempTile;
        gridStorage[(3,3)].gameObject.transform.Find("WestDoor").gameObject.SetActive(true);
        gridStorage[(3,3)].GetComponent<LevelTile>().exit = 3; 

        tempTile = Instantiate(demoTile, Vector3.zero, Quaternion.identity);
        tempTile.transform.parent = GameObject.Find("GridManager").transform; 
        tempTile.name = "LT[2][3]";
        tempTile.transform.position = gridStorage[(2,3)].transform.position;
        Destroy(gridStorage[(2,3)]); 
        gridStorage[(2,3)] = tempTile;
        gridStorage[(2,3)].gameObject.transform.Find("WestDoor").gameObject.SetActive(true);
        gridStorage[(2,3)].GetComponent<LevelTile>().exit = 3; 

        tempTile = Instantiate(demoTile, Vector3.zero, Quaternion.identity);
        tempTile.transform.parent = GameObject.Find("GridManager").transform; 
        tempTile.name = "LT[1][3]";
        tempTile.transform.position = gridStorage[(1,3)].transform.position;
        Destroy(gridStorage[(1,3)]); 
        gridStorage[(1,3)] = tempTile;
        gridStorage[(1,3)].gameObject.transform.Find("NorthDoor").gameObject.SetActive(true);
        gridStorage[(1,3)].GetComponent<LevelTile>().exit = 0;   

        tempTile = Instantiate(demoTile, Vector3.zero, Quaternion.identity);
        tempTile.transform.parent = GameObject.Find("GridManager").transform; 
        tempTile.name = "LT[1][4]";
        tempTile.transform.position = gridStorage[(1,4)].transform.position;
        Destroy(gridStorage[(1,4)]); 
        gridStorage[(1,4)] = tempTile;
        gridStorage[(1,4)].gameObject.transform.Find("EastDoor").gameObject.SetActive(true);
        gridStorage[(1,4)].GetComponent<LevelTile>().exit = 1;   

        tempTile = Instantiate(demoTile, Vector3.zero, Quaternion.identity);
        tempTile.transform.parent = GameObject.Find("GridManager").transform; 
        tempTile.name = "LT[2][4]";
        tempTile.transform.position = gridStorage[(2,4)].transform.position;
        Destroy(gridStorage[(2,4)]); 
        gridStorage[(2,4)] = tempTile;
        gridStorage[(2,4)].gameObject.transform.Find("EastDoor").gameObject.SetActive(true);
        gridStorage[(2,4)].GetComponent<LevelTile>().exit = 1;  

        tempTile = Instantiate(demoTile, Vector3.zero, Quaternion.identity);
        tempTile.transform.parent = GameObject.Find("GridManager").transform; 
        tempTile.name = "LT[3][4]";
        tempTile.transform.position = gridStorage[(3,4)].transform.position;
        Destroy(gridStorage[(3,4)]); 
        gridStorage[(3,4)] = tempTile;
        gridStorage[(3,4)].gameObject.transform.Find("EastDoor").gameObject.SetActive(true);
        gridStorage[(3,4)].GetComponent<LevelTile>().exit = 1;  
    }
}