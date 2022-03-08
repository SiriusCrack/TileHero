using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BoundaryTest
{
    Enemy enemy;
    GameObject gameObject;
    
    [SetUp]
    public void setUp()
    {
        gameObject = new GameObject();
        enemy = gameObject.AddComponent<Enemy>();
    }

    [Test]
    public void Health_Boundary()
    {
        enemy.health = 100;
        enemy.takeDamage(33);
        Debug.Log("Expected:" + 67 + " Actual:" + enemy.health);
        Assert.AreEqual(67,enemy.health);
        enemy.takeDamage(33);
        Debug.Log("Expected:" + 34 + " Actual:" + enemy.health);
        Assert.AreEqual(34,enemy.health);
        enemy.takeDamage(33);
        Debug.Log("Expected:" + 1 + " Actual:" + enemy.health);
        Assert.AreEqual(1,enemy.health);
        enemy.takeDamage(33);
        Debug.Log("Expected:" + 0 + " Actual:" + enemy.health);
        Assert.AreEqual(0,enemy.health);
    }

    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
