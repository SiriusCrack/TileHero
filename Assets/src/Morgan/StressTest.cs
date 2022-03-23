using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StressTest : MonoBehaviour
{
    /*[SerializeField] tileFactory tileFactory;
    private float x = -1.5f;
    private float y = 4.7f;
    private float width = 8f;
    private float height = -0.03f;
    private int tile;
    private int tileCount = 0;*/

    /*void FixedUpdate()
    {
        var spawnedTile1 = tileFactory.GetNewTile(tile);
        tileCount++;
        File.WriteAllText("MBStressData", tileCount.ToString());
        spawnedTile1.name = $"{x},{y}";
        spawnedTile1.transform.position = new Vector2(x,y);
        var spawnedTile2 = tileFactory.GetNewTile(tile);
        tileCount++;
        //File.WriteAllText(data, tile);
        spawnedTile2.name = $"{x},{y-1}";
        spawnedTile2.transform.position = new Vector2(x,y-1);
        var spawnedTile3 = tileFactory.GetNewTile(tile);
        tileCount++;
        //File.WriteAllText(data, tile);
        spawnedTile3.name = $"{x},{y-2}";
        spawnedTile3.transform.position = new Vector2(x,y-2);
        var spawnedTile4 = tileFactory.GetNewTile(tile);
        tileCount++;
        //File.WriteAllText(data, tile);
        spawnedTile4.name = $"{x},{y-3}";
        spawnedTile4.transform.position = new Vector2(x,y-3);
        var spawnedTile5 = tileFactory.GetNewTile(tile);
        tileCount++;
        //File.WriteAllText(data, tile);
        spawnedTile5.name = $"{x},{y-4}";
        spawnedTile5.transform.position = new Vector2(x,y-4);
        var spawnedTile6 = tileFactory.GetNewTile(tile);
        tileCount++;
        //File.WriteAllText(data, tile);
        spawnedTile6.name = $"{x},{y-5}";
        spawnedTile6.transform.position = new Vector2(x,y-5);
        var spawnedTile7 = tileFactory.GetNewTile(tile);
        tileCount++;
        //File.WriteAllText(data, tile);
        spawnedTile7.name = $"{x},{y-6}";
        spawnedTile7.transform.position = new Vector2(x,y-6);
        if(x > width) {
            x = -1.5f;
        }
        if(y > height) {
            y = 4.7f;
        }
        tile++;
        tile = tile%3;
        x += 0.05f;
        y -= 0.0001f;
    }*/
}
