using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class BleedCultistsSpriteChange : MonoBehaviour
{

    [SerializeField] Sprite CultistsBleed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBleed()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = CultistsBleed;
        Thread.Sleep(3000);
        //turn off sprite
    }
}
