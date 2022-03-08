using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Boundary_Test
{
    Weapon weapon;
    Enemy enemy;
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
        weapon.weaponSpeed(10);   
        Debug.Log("Expected:" + 10 + " Actual:" + weapon.atk_speed);
        Assert.AreEqual(10,weapon.atk_speed);

        weapon.weaponSpeed(5);    
        Debug.Log("Expected:" + 5 + " Actual:" + weapon.atk_speed);
        Assert.AreEqual(5,weapon.atk_speed);

        weapon.weaponSpeed(0);    
        Debug.Log("Expected:" + 5 + " Actual:" + weapon.atk_speed);
        Assert.AreEqual(5,weapon.atk_speed);
        
    }

    [Test]
    public void Damage_Recieved()
    {
        enemy.health = 100;

        enemy.takeDamage(50);
        Debug.Log("Expected:" + 50 + " Actual:" + enemy.health);
        Assert.AreEqual(50,enemy.health);

        enemy.takeDamage(49);
        Debug.Log("Expected:" + 1 + " Actual:" + enemy.health);
        Assert.AreEqual(1,enemy.health);      

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