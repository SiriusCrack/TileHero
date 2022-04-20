using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInventory : MonoBehaviour
{
    //builds the inventory 
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;
    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        
    }
}
