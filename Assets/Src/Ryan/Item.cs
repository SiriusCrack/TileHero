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
            case ItemType.Empty: return ItemAssets.Instance.emptySprite;
            case ItemType.Sword: return ItemAssets.Instance.swordSprite;
            case ItemType.Shield: return ItemAssets.Instance.shieldSprite;
            case ItemType.Boots: return ItemAssets.Instance.bootsSprite;
            case ItemType.Helmet: return ItemAssets.Instance.helmetSprite;
            case ItemType.Chest: return ItemAssets.Instance.chestSprite;
            case ItemType.Legs: return ItemAssets.Instance.legsSprite;
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