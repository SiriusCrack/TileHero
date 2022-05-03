using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtons : MonoBehaviour
{
    public static InventoryButtons instance { get; private set; }

    public GameObject buttonPrefab;
    public GameObject buttonParent;

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
    }

    public void UpdateInventory()
    {
        GameObject[] existingButtons = GameObject.FindGameObjectsWithTag("InventoryButton");
        foreach (GameObject target in existingButtons)
        {
            GameObject.Destroy(target);
        }

        foreach (Item item in Inventory.instance.GetInventory())
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);


            newButton.GetComponent<ButtonInfo>().Pic.sprite = item.GetSprite();
            newButton.GetComponent<Button>().onClick.AddListener(() => Equipped.instance.EquipItem(item));
        }
    }
}