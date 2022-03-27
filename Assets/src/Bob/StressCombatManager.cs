using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressCombatManager : MonoBehaviour
{
    public Hero hero;
    public Enemy[] enemies;
    public Enemy inactiveEnemy;
    float heroPos;
    float enemyPos;
    bool messagePrinted;
    bool inCombat;
    //int currentEnemy = 0;
    //int nextEnemy = 1;
    AttackCommand attack;
    int i;
    int j;

    // Start is called before the first frame update
    void Start()
    {
        //inactiveEnemy.gameObject.SetActive(false);
        //enemies[0] = inactiveEnemy;
        heroPos = hero.transform.localPosition.y;
        messagePrinted = false;
        inCombat = false;
    }


    void FixedUpdate()
    {
        //Debug.Log("enemy attack");
        //enemies[0].attackTimer = 0;
        //attack = new AttackCommand(enemies[0], enemies[1], enemies[0].weapon.atk_damage);
        //enemies[1].receiveAttack(attack);
        //Destroy(attack);

        //enemy count
        for (i = 0; i < 199; i++)
        {
            for (j = 0; j < 199; j++)
            {
                Debug.Log("enemy attack");
                enemies[i].attackTimer = 0;
                attack = new AttackCommand(enemies[i], enemies[i+1], enemies[i].weapon.atkDamage);
                enemies[i].receiveAttack(attack);
                Destroy(attack);
                //if (enemies[i].attackTimer >= enemies[i].weapon.atk_speed)
                //{
                //    Debug.Log("enemy attack");
                //    enemies[i].attackTimer = 0;
                //    attack = new AttackCommand(enemies[i], enemies[j], enemies[i].weapon.atk_damage);
                //    enemies[j].receiveAttack(attack);
                //    Destroy(attack);
                //}
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (i = 0; i < 50; i++)
        {
            for (j = 0; j < 50; j++)
            {
                if (enemies[i].attackTimer >= enemies[i].weapon.atkSpeed)
                {
                    Debug.Log("enemy attack");
                    enemies[i].attackTimer = 0;
                    attack = new AttackCommand(enemies[i], enemies[j], enemies[i].weapon.atkDamage);
                    enemies[j].receiveAttack(attack);
                    Destroy(attack);
                }
            }
        }
        /*
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
        */
    }
}