using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance1 { get; private set; }

    private void Awake()
    {
        Instance1 = this;
    }
    //A simple way to easily incorperate the item sprites into the code
    public Sprite emptySprite;
    public Sprite swordSprite;
    public Sprite shieldSprite;
    public Sprite bootsSprite;
    public Sprite helmetSprite;
    public Sprite chestSprite;
    public Sprite legsSprite;



}
