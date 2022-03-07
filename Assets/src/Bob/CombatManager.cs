using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public Hero hero;
    public Enemy enemy;
    float heroPos;
    float enemyPos;
    bool messagePrinted;

    // Start is called before the first frame update
    void Start()
    {
        heroPos = hero.transform.localPosition.y;
        messagePrinted = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(heroPos);
        heroPos = hero.transform.localPosition.x;
        enemyPos = enemy.transform.localPosition.x;
        if ((Mathf.Abs(heroPos - enemyPos) < 0.5) && (messagePrinted == false))
        {
            Debug.Log("Combat would begin here");
            messagePrinted = true;
        }
    }
}