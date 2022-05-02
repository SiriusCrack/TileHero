using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipped : MonoBehaviour
{
    public const int MAX_EQUIPPED_SIZE = 6;

    public static Equipped instance { get; private set; }

    private List<Item> equippedList;

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

        equippedList = new List<Item>();
        Debug.Log("Initialized empty equipped slots");
    }

    public void EquipItem(Item item)
    {
        if (equippedList.Count < MAX_EQUIPPED_SIZE)
        {
            foreach (Item equippedItem in equippedList)
            {
                if (equippedItem.GetItemType() == item.GetItemType())
                {
                    Inventory.instance.AddItem(equippedItem);
                    equippedList.RemoveAt(equippedList.IndexOf(equippedItem));
                    break;
                }
            }
            equippedList.Add(item);
            Inventory.instance.RemoveItem(item);
        }
        else
        {
            Debug.Log("Exceeded maximum equipped size");
        }

        EquippedButtons.instance.UpdateEquipped();
    }

    public void RemoveEquippedItem(Item item)
    {
        int index = 0;
        foreach (Item removedEquipped in equippedList)
        {
            if (removedEquipped.GetItemType() == item.GetItemType())
            {
                equippedList.RemoveAt(equippedList.IndexOf(removedEquipped));
                Inventory.instance.AddItem(item);
                break;
            }
        }

        EquippedButtons.instance.UpdateEquipped();
    }

    public List<Item> GetEquipped()
    {
        return equippedList;
    }

    public int EquippedSize()
    {
        return equippedList.Count;
    }
}