using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Empty,
        Sword,
        Shield,
        Boots,
        Helmet,
        Chest,
        Legs,
    }

    public enum ItemSlot
    {
        A,
        B,
        C,
        D,
        E,
        F
    }

    public ItemType itemType;
    public ItemSlot itemSlot;

    public ItemType GetItemType()
    {
        return itemType;
    }

    public ItemSlot GetItemSlot()
    {
        return itemSlot;
    }

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Empty: return ItemAssets.Instance1.emptySprite;
            case ItemType.Sword: return ItemAssets.Instance1.swordSprite;
            case ItemType.Shield: return ItemAssets.Instance1.shieldSprite;
            case ItemType.Boots: return ItemAssets.Instance1.bootsSprite;
            case ItemType.Helmet: return ItemAssets.Instance1.helmetSprite;
            case ItemType.Chest: return ItemAssets.Instance1.chestSprite;
            case ItemType.Legs: return ItemAssets.Instance1.legsSprite;
        }
    }

    public string ItemTypeString()
    {
        switch (itemSlot)
        {
            default: return "Other";
            case ItemSlot.A: return "A";
            case ItemSlot.B: return "B";
            case ItemSlot.C: return "C";
            case ItemSlot.D: return "D";
            case ItemSlot.E: return "E";
            case ItemSlot.F: return "F";
        }
    }

}