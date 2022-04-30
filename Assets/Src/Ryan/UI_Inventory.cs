using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private InventoryTest inventoryT;
    private Inventory inventory;
    public Button ItemButton;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    public Image HelmImage;
    public Image ChestImage;
    public Image LegImage;
    public Image MainHandImage;
    public Image OffHandImage;
    public Image BootsImage;





    private void Update()
    {
        RefreshInventoryItems();
    }
    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }
    public void SetInventoryT(InventoryTest inventoryT)
    {
        this.inventoryT = inventoryT;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
     {
         RefreshInventoryItems();
     }


    private void RefreshInventoryItems()
    {
        int count = 0;
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 110f;
        Button b;
        HelmImage.sprite = inventory.GetHelmSlot().GetSprite();
        ChestImage.sprite = inventory.GetChestSlot().GetSprite();
        LegImage.sprite = inventory.GetLegSlot().GetSprite();
        BootsImage.sprite = inventory.GetBootsSlot().GetSprite();
        MainHandImage.sprite = inventory.GetMainHandSlot().GetSprite();
        OffHandImage.sprite = inventory.GetOffHandSlot().GetSprite();

        foreach (Item item in inventory.GetItemList())
        {
            if (item.GetItemClass() == 1)
            {
                RectTransform itemSlotRectTrasnfrom = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTrasnfrom.gameObject.SetActive(true);
                itemSlotRectTrasnfrom.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                Image image = itemSlotRectTrasnfrom.Find("Icon").GetComponent<Image>();
                image.sprite = item.GetSprite();
                b = itemSlotRectTrasnfrom.Find("Button").GetComponent<Button>();
                b.onClick.AddListener(delegate { HeroInventory.EquipItem(count); });
                count++;
                x++;
                if (x > 7)
                {
                    x = 0;
                    y--;
                }
            }
        }
    }
}
