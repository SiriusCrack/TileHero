using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleItem : Item
{
    public override int GetItemClass()
    {
        Debug.Log("Subclass");
        return 0;
    }



}
