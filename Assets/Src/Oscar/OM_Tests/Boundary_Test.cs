using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Boundary_Test
{
    Weapon weapon;
    Enemy enemy;
    BleedEffect bleedEffect;
    PoisonEffect poisonEffect;
    BuffEffect buffEffect;
    GameObject gameObject;

    [SetUp]
    public void setUp()
    {
        gameObject = new GameObject();
        weapon = gameObject.AddComponent<Weapon>();
        
        gameObject = new GameObject();
        enemy = gameObject.AddComponent<Enemy>();
    }

    [Test]
    public void WeaponSpeed()
    {
        weapon.UpdateSpeed(100);   
        Debug.Log("Expected:" + 100 + " Actual:" + weapon.atkSpeed);
        Assert.AreEqual(100,weapon.atkSpeed);

        weapon.UpdateSpeed(50);    
        Debug.Log("Expected:" + 50 + " Actual:" + weapon.atkSpeed);
        Assert.AreEqual(50,weapon.atkSpeed);

        weapon.UpdateSpeed(5);    
        Debug.Log("Expected:" + 5 + " Actual:" + weapon.atkSpeed);
        Assert.AreEqual(5,weapon.atkSpeed);
        
    }

    [Test]
    public void Damage_Recieved() //for weapon class
    {
        enemy.health = 100;

        enemy.takeDamage(50);
        Debug.Log("Expected:" + 50 + " Actual:" + enemy.health);
        Assert.AreEqual(50,enemy.health);

        enemy.takeDamage(10);
        Debug.Log("Expected:" + 40 + " Actual:" + enemy.health);
        Assert.AreEqual(40,enemy.health);      

        enemy.takeDamage(20);
        Debug.Log("Expected:" + 20 + " Actual:" + enemy.health);
        Assert.AreEqual(20,enemy.health);

        enemy.takeDamage(15);
        Debug.Log("Expected:" + 5 + " Actual:" + enemy.health);
        Assert.AreEqual(5,enemy.health);

        enemy.takeDamage(100);
        Debug.Log("Expected:" + 0 + " Actual:" + enemy.health);
        Assert.AreEqual(0,enemy.health);             
        
    }

    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}