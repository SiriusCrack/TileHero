/*using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryTest
{
    GameObject gameObject;
    GoldManager gold;
    private Inventory inventory;
    public List<Item> itemList;
    
    [SetUp]
    public void setUp()
    {
        //gameObject = new GameObject();
        gold = new GoldManager(25);
        //inventory = gameObject.AddComponent<Inventory>();
        
    }
    

    // A Test behaves as an ordinary method
    [Test]
    public void Inventory_Bound()
    {
        inventory = new Inventory();
        inventory.AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        Debug.Log("Expected:" + 15 + " Actual:" + itemList.Count);
        Assert.AreEqual(15, itemList.Count);
        inventory.AddItem(new Item { itemType = Item.ItemType.Chest, amount = 1 });
        Debug.Log("Expected:" + 16 + " Actual:" + itemList.Count);
        Assert.AreEqual(16, itemList.Count);
        inventory.AddItem(new Item { itemType = Item.ItemType.Chest, amount = 1 });
        Debug.Log("Expected:" + 16 + " Actual:" + itemList.Count);
        Assert.AreEqual(16, itemList.Count);
    }

    [Test]
    public void Gold_Bounds() 
    {
        Debug.Log("Current Gold:" + gold.Gold);
        gold.RemoveGold(10);
        Debug.Log("Expected:" + 15 + " Actual:" + gold.Gold);
        gold.RemoveGold(10);
        Debug.Log("Expected:" + 5 + " Actual:" + gold.Gold);
        gold.RemoveGold(10);
        Debug.Log("Expected:" + 5 + " Actual:" + gold.Gold);
    }

    [Test]
    public void Gold_Overflow()
    {
        gold.Gold = 2147483647;
        gold.RemoveGold(-1);
        Debug.Log("Expected:" + 2147483648 + " Actual:" + gold.Gold);
    }

    [TearDown]
    public void Teardown()
    {
        //inventory = null;
    }
}
*/