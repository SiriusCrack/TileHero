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

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Empty:    return ItemAssets.Instance.swordSprite;
            case ItemType.Sword:    return ItemAssets.Instance.swordSprite;
            case ItemType.Shield:   return ItemAssets.Instance.shieldSprite;
            case ItemType.Boots:    return ItemAssets.Instance.bootsSprite;
            case ItemType.Helmet:   return ItemAssets.Instance.helmetSprite;
            case ItemType.Chest:    return ItemAssets.Instance.chestSprite;
            case ItemType.Legs:     return ItemAssets.Instance.swordSprite;
        }
    }
}
