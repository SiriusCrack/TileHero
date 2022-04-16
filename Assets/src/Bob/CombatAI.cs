using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatAI : MonoBehaviour
{
    float health;
    float maxHealth;

    Vector3 barLocation;
    public Vector3 targetLocation;

    public Vector3 heroPos;

    public GameObject healthBar;
    public Slider healthBarSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMaxHealth(float tempMaxHealth)
    {
        maxHealth = tempMaxHealth;
        health = tempMaxHealth;
    }

    public void updateSlider(float newHealth)
    {
        health = newHealth;
        healthBarSlider.value = health / maxHealth;
    }

    public void updateLocation(Vector3 npcLocation)
    {
        barLocation = new Vector3(npcLocation.x, npcLocation.y - .15f, npcLocation.z);
        healthBar.transform.position = Camera.main.WorldToScreenPoint(barLocation);
    }

    public virtual Vector3 engageCombat(Vector3 npcL)
    {
        heroPos = GameObject.FindGameObjectWithTag("hero").transform.position;
        float yDist = npcL.y - heroPos.y;
        float xDist = npcL.x - heroPos.x;
        targetLocation = new Vector3(npcL.x - (xDist / 2), npcL.y - (yDist / 2), npcL.z);
        return targetLocation;

        /*heroPos = GameObject.FindGameObjectWithTag("hero").transform.position;
        targetLocation = new Vector3((npcL.x + heroPos.x) / 2, (npcL.y + heroPos.y) / 2, (npcL.z + heroPos.z) / 2);
        return targetLocation;*/
    }
}
