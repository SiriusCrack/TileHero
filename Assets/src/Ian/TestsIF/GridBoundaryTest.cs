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
        test.height = -1;
        test.width = -1;
    }
    
    [Test]
    public void DataStorageBoundaryTest() {
        Vector2 testindex = new Vector2(0,0);
        Debug.Log((string)test.GridStorage[testindex]);
    }

    [Test] 
    public void GridSizeBoundaryTest() {
        if (test.height < 1) {
            Debug.Log("Can't initialize grid height.");
        }
        if (test.width < 1) {
            Debug.Log("Can't initialize grid width.");
        }
    }
}
