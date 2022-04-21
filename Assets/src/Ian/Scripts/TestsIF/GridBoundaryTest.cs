/*
 * Filename: GridBoundaryTest.cs
 * Developer: Ian Fleming
 * Purpose: This script creates the tests for my implementation to be used in the Test Runner.
 */

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/*
*   Summary: Script responsible for setting up the necessary tests for my implementation.
*/
public class GridBoundaryTest
{

    /*
     * Summary: Function to test if the boundaries of the grid are valid. E.g. greater than zero.
     *
     * Parameters: None
     *
     * Returns: None
    */
    [Test]
    public void CheckGridBoundaries()
    {
        GameObject GM = GameObject.Find("GridManager");

        int width = GM.gameObject.GetComponent<GridManager>().width;
        int height = GM.gameObject.GetComponent<GridManager>().height;

        Assert.IsTrue(width > 0);
        Assert.IsTrue(height > 0);
    }

    /*
     * Summary: Function to test if the tile objects initialized by the grid are not null.
     *
     * Parameters: None
     *
     * Returns: None
    */
    [Test]
    public void TestTileForNull() {

        GameObject GM = GameObject.Find("GridManager");

        GameObject Tile = GM.gameObject.GetComponent<GridManager>().eTile;

        Assert.IsNotNull(Tile);
    }
}
