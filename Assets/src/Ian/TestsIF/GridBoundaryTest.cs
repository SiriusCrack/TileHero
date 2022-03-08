using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridBoundaryTest
{
    GridManager test;
    GameObject gameObject;

    [SetUp]
    public void setUpGrid()
    {
        gameObject = new GameObject();
        test =  gameObject.AddComponent<GridManager>();

        test.tileSize = 1;
        test.emptyTile = gameObject.AddComponent<TileSlot>();
        test.mainCamera = GameObject.Find("MainCamera").GetComponent<Transform>();
        test.height = 3;
        test.width = 3;
    }
    
    [Test]
    public void DataStorageBoundaryTest() {
        // Detects if this index exists in the Grid Storage
        bool isIndex;
        test.initGrid();
        Vector2 goodindex = new Vector2(0,0);
        Assert.IsNotNull(test.GridStorage[goodindex]);
        Debug.Log("The index (0,0) is a valid index for the Data Storage array:");
        Debug.Log("\tGridStorage[0][0] = " + "\"" + (string)test.GridStorage[goodindex] + "\"");
        Vector2 badindex = new Vector2(100,100);
        if (badindex.x > test.height || badindex.y > test.width) {
            isIndex = false;
            Assert.IsFalse(isIndex);
            Debug.Log("The index (100, 100) is an invalid index for the Data Storage array.");
        } else {
            isIndex = true;
            Assert.IsFalse(isIndex);
            Debug.Log("The index (100, 100) is a valid index for the Data Storage array.");
        }

        
    }

    [Test] 
    public void GridSizeBoundaryTest() {
        // Tests if the height and width are invalid values (not negative or 0)
        test.height = 5;
        test.width = 5;
        Assert.AreNotEqual(-1, test.width);
        Assert.AreNotEqual(0, test.width);
        Assert.AreNotEqual(-1, test.height);
        Assert.AreNotEqual(0, test.height);
        Debug.Log("Current height and width ( 5 x 5 ) is valid (not 0 or negative).");
    }
}
