using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public event EventHandler OnItemListChanged;

    public List<Item> itemList;

    public Item HelmetSlot      = new Item { itemType = Item.ItemType.Empty, amount = 1 };
    public Item ChestSlot       = new Item { itemType = Item.ItemType.Empty, amount = 1 };
    public Item LegSlot         = new Item { itemType = Item.ItemType.Empty, amount = 1 };
    public Item MainHandSlot    = new Item { itemType = Item.ItemType.Empty, amount = 1 };
    public Item OffHandSlot     = new Item { itemType = Item.ItemType.Empty, amount = 1 };
    public Item BootsSlot       = new Item { itemType = Item.ItemType.Empty, amount = 1 };

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
        AddItem(new Item { itemType = Item.ItemType.Chest, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Chest, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Chest, amount = 1 });
    }



    public int EquipItem(Item item)
    {

        if (item.itemType == Item.ItemType.Helmet)
        {
            if (HelmetSlot.itemType == Item.ItemType.Empty)
            {
                HelmetSlot = item;
                return 1;
            }
            else
            {
                Item temporary = HelmetSlot;
                HelmetSlot = item;
                AddItem(temporary);
                return 1;
            }
        }

        if (item.itemType == Item.ItemType.Chest)
        {
            if (ChestSlot.itemType == Item.ItemType.Empty)
            {
                ChestSlot = item;
                return 1;
            }
            else
            {
                Item temporary = ChestSlot;
                ChestSlot = item;
                AddItem(temporary);
                return 1;
            }
        }

        if (item.itemType == Item.ItemType.Legs)
        {
            if (LegSlot.itemType == Item.ItemType.Empty)
            {
                LegSlot = item;
                return 1;
            }
            else
            {
                Item temporary = LegSlot;
                LegSlot = item;
                AddItem(temporary);
                return 1;
            }
        }

        if (item.itemType == Item.ItemType.Sword)
        {
            if (MainHandSlot.itemType == Item.ItemType.Empty)
            {
                MainHandSlot = item;
                return 1;
            }
            else
            {
                Item temporary = MainHandSlot;
                MainHandSlot = item;
                AddItem(temporary);
                return 1;
            }
        }

        if (item.itemType == Item.ItemType.Shield)
        {
            if (OffHandSlot.itemType == Item.ItemType.Empty)
            {
                OffHandSlot = item;
                return 1;
            }
            else
            {
                Item temporary = OffHandSlot;
                OffHandSlot = item;
                AddItem(temporary);
                return 1;
            }
        }

        if (item.itemType == Item.ItemType.Boots)
        {
            if (BootsSlot.itemType == Item.ItemType.Empty)
            {
                BootsSlot = item;
                return 1;
            }
            else
            {
                Item temporary = BootsSlot;
                BootsSlot = item;
                AddItem(temporary);
                return 1;
            }
        }

        return 0;






        //OnItemListChanged?.Invoke(this, EventArgs.Empty);
        //Debug.Log(itemList.Count);
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

    public List<Item> GetInventory()
    {
        return itemList;
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }



    public List<Item> GetItemList()
    {
        return itemList;
    }
    
}
