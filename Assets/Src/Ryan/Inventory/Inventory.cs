using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public const int MAX_INVENTORY_SIZE = 16;

    public static Inventory instance { get; private set; }

    private List<Item> itemList;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        itemList = new List<Item>();
        Debug.Log("Initialized empty inventory");

        AddItem(new Item { itemType = Item.ItemType.Sword, itemSlot = Item.ItemSlot.A });
        AddItem(new Item { itemType = Item.ItemType.Chest, itemSlot = Item.ItemSlot.B });
        AddItem(new Item { itemType = Item.ItemType.Helmet, itemSlot = Item.ItemSlot.B });
        AddItem(new Item { itemType = Item.ItemType.Legs, itemSlot = Item.ItemSlot.E });
        AddItem(new Item { itemType = Item.ItemType.Shield, itemSlot = Item.ItemSlot.F }); ;
        AddItem(new Item { itemType = Item.ItemType.Boots, itemSlot = Item.ItemSlot.C });
    }

    public void AddItem(Item item)
    {
        if (itemList.Count < MAX_INVENTORY_SIZE)
        {
            itemList.Add(item);
            Debug.Log("Added item of type " + item.ItemTypeString());
        }
        else
        {
            Debug.Log("Exceeded maximum inventory size");
        }

        InventoryButtons.instance.UpdateInventory();
    }

    public void RemoveItem(Item item)
    {
        foreach (Item removedItem in itemList)
        {
            if (removedItem.GetItemType() == item.GetItemType())
            {
                itemList.RemoveAt(itemList.IndexOf(removedItem));
                break;
            }
        }

        InventoryButtons.instance.UpdateInventory();
    }

    public List<Item> GetInventory()
    {
        return itemList;
    }

    public int InventorySize()
    {
        return itemList.Count;
    }
}