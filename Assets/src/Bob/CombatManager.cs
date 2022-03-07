using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public Hero hero;
    public Enemy[] enemies;
    public Enemy inactiveEnemy;
    float heroPos;
    float enemyPos;
    bool messagePrinted;
    bool inCombat;
    int currentEnemy = 0;
    int nextEnemy = 1;
    AttackCommand attack;

    // Start is called before the first frame update
    void Start()
    {
        inactiveEnemy.gameObject.SetActive(false);
        enemies[0] = inactiveEnemy;
        heroPos = hero.transform.localPosition.y;
        messagePrinted = false;
        inCombat = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(heroPos);
        heroPos = hero.transform.localPosition.x;
        if (enemies[currentEnemy])
        {
            enemyPos = enemies[currentEnemy].transform.localPosition.x;
        }
        if (hero.collectEnemy == true)
        {
            enemies[nextEnemy] = hero.currentEnemy;
            nextEnemy++;
            hero.collectEnemy = false;
            if (currentEnemy == 0)
            {
                currentEnemy++;
            }
            Debug.Log("collection");
            Debug.Log(enemies[currentEnemy]);
        }

        if (inCombat == true)
        {
            if (enemies[currentEnemy].health == 0)
            {
                Debug.Log("death", enemies[currentEnemy]);
                Debug.Log(enemies);
                enemies[currentEnemy].transform.Translate(1000, 1000, 0);
                enemies[currentEnemy].gameObject.SetActive(false);
                currentEnemy++;
                hero.endCombat();
                inCombat = false;
                messagePrinted = false;
                enemyPos = 1000;
            }
            if (hero.health == 0)
            {
                hero.gameObject.SetActive(false);
            }
            if (enemies[currentEnemy].attackTimer >= enemies[currentEnemy].weapon.atk_speed)
            {
                Debug.Log("enemy attack");
                enemies[currentEnemy].attackTimer = 0;
                attack = new AttackCommand(enemies[currentEnemy], hero, enemies[currentEnemy].weapon.atk_damage);
                hero.receiveAttack(attack);
                Destroy(attack);    
            }
            if (hero.attackTimer >= hero.weapon.atk_speed)
            {
                Debug.Log("hero attack");
                hero.attackTimer = 0;
                attack = new AttackCommand(hero, enemies[currentEnemy], hero.weapon.atk_damage);
                enemies[currentEnemy].receiveAttack(attack);
                Destroy(attack);
            }
        }
        if ((Mathf.Abs(heroPos - enemyPos) < 0.5) && (messagePrinted == false))
        {
            hero.startCombat();
            Debug.Log("Combat would begin here");
            inCombat = true;
            messagePrinted = true;
            hero.attackTimer = 0;
            enemies[currentEnemy].attackTimer = 0;
        }
    }
}