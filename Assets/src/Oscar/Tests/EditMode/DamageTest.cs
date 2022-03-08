using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DamageTest
{
    Enemy enemy;
    GameObject gameObject;

    [Test]
    public void DamageTest1()
    {
        GameObject gameObject = new GameObject();
        enemy = gameObject.AddComponent<Enemy>();
    }


    [UnityTest]
    public IEnumerator DamageTestWithEnumeratorPasses()
    {
        enemy.health = 100;
        enemy.takeDamage(101);
        Assert.AreEqual(expected: 0, actual: enemy.health);
        
        yield return null;
    }
}
