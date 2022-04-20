
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public Text GoldCounter;

    public void UpdateGoldText(int amount)
    {
        GoldCounter.text = amount.ToString();
    }


}
