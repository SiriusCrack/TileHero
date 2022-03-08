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
    }
    
    [Test]
    public void DataStorageBoundaryTest() {

    }

    [Test] 
    public void GridSizeBoundaryTest() {
        
    }
}
