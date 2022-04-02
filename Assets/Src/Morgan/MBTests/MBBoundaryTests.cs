using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MB_BoundaryTests
{
    GameObject tileTypeA, tileTypeB;


    [SetUp]
    public void SetUp()
    {
        tileTypeA = new GameObject();
        tileTypeB = new GameObject();
        tileTypeA.AddComponent<TileTypeA>();
        tileTypeB.AddComponent<TileTypeB>();
        
    }


    [Test]
    public void CheckValidCreation()
    {
        Debug.Log("Created GameObject Tile.");
        Assert.IsNotNull(tileTypeA,"Tile exists");
        Debug.Log("Tile exists.");
    }

    [Test]
    public void CheckUniqueness()
    {
        Debug.Log("Creating all tile types...");
        Debug.Log("Created " + tileTypeA);
        Debug.Log("Created " + tileTypeB);
        Assert.AreNotEqual(tileTypeA, tileTypeB, "Tiles are unique.");
        Debug.Log("Tiles are unique.");
    }
    
    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(tileTypeA);
        GameObject.DestroyImmediate(tileTypeB);
    }
}
