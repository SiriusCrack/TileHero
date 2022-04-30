using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicID : MonoBehaviour
{
    
    public int ID;

    public void SetID(int input)
    {
        ID = input;
    }

    public int GetID()
    {
        return ID;
    }
}
