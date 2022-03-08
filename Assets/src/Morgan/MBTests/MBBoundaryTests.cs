using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MB_BoundaryTests
{
    GameObject tile1, tile2;
    levelTile Tile1, Tile2;

    [SetUp]
    public void setUp() {
        tile1 = new GameObject();
        tile2 = new GameObject();
        Tile1 = tile1.AddComponent<tileType1>();
        Tile2 = tile2.AddComponent<tileType2>();
    }

    [Test]
    public void NoDuplicates()
    {
        Assert.IsNotNull(Tile1,"Tile exists");
    }

    [Test]
    public void TileExists()
    {
        Assert.AreNotEqual(Tile1, Tile2, "Tiles are unique");
    }
    
    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(Tile1);
        GameObject.DestroyImmediate(Tile2);
    }
}
