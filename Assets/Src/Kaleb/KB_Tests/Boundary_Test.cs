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

    [Test]
    public void Damage_Boundary()
    {

        enemy.setAtk(10);
        enemy.debuff("atk", .5f);
        Debug.Log("Expected:" + 9.5f + " Actual:" + enemy.getAtk());
        Assert.AreEqual(9.5f, enemy.getAtk());
        enemy.debuff("atk", 9f);
        Debug.Log("Expected:" + 0.5f + " Actual:" + enemy.getAtk());
        Assert.AreEqual(.5f, enemy.getAtk());
        enemy.debuff("atk", 1f);
        Debug.Log("Expected:" + 1f + " Actual:" + enemy.getAtk());
        Assert.AreEqual(1, enemy.getAtk());
        
    }

    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
