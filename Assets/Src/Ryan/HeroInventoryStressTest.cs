using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInventoryStressTest : MonoBehaviour
{
    private InventoryTest inventory;
    [SerializeField] private UI_Inventory uiInventory;
    private void Awake()
    {
        inventory = new InventoryTest();
        uiInventory.SetInventoryT(inventory);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}


