using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileInventory : MonoBehaviour
{
    public GameObject SelectedTile;

    void Start()
        {
            //Start the coroutine we define below named ExampleCoroutine.
            //StartCoroutine(ExampleCoroutine());
        }

        IEnumerator ExampleCoroutine()
        {
            //Print the time of when the function is first called.
            Debug.Log("Started Coroutine at timestamp : " + Time.time);

            WaitForSeconds wait = new WaitForSeconds(2f);

            while(true) {
                Debug.Log(SelectedTile);
                yield return wait;
            }
        }
}
