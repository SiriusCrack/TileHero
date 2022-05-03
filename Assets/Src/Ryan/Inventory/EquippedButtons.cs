using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedButtons : MonoBehaviour
{
    public static EquippedButtons instance { get; private set; }

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

    public void UpdateEquipped()
    {
        GameObject[] existingButtons = GameObject.FindGameObjectsWithTag("EquippedButton");
        foreach (GameObject target in existingButtons)
        {
            GameObject.Destroy(target);
        }

        foreach (Item item in Equipped.instance.GetEquipped())
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);

            newButton.GetComponent<ButtonInfo>().Pic.sprite = item.GetSprite();
            newButton.GetComponent<Button>().onClick.AddListener(() => Equipped.instance.RemoveEquippedItem(item));
        }
    }
}