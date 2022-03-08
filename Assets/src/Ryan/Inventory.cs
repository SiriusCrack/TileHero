using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public event EventHandler OnItemListChanged;

    public List<Item> itemList;

    public Inventory()
    {
        Debug.Log("inventory add");
        itemList = new List<Item>();
        AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Shield, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Boots, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Helmet, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Chest, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Shield, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Boots, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Helmet, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Chest, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Shield, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Boots, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Helmet, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Chest, amount = 1 });   
    }

    public void AddItem(Item item)
    {
        if (itemList.Count < 16)
        {
            itemList.Add(item);
            OnItemListChanged?.Invoke(this, EventArgs.Empty);
            Debug.Log(itemList.Count);
        }
        else
        {
            Debug.Log("inventory full, item not added");
        }
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
    
}
