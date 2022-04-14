using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatAI : MonoBehaviour
{
    float health;
    float maxHealth;

    public Slider healthBarSlider;
    GameObject healthBar;

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

    public void updateSlider(float damage)
    {
        health -= damage;
        healthBarSlider.value = health / maxHealth;
    }

    public void updateLocation(Vector3 npcLocation)
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        Debug.Log("npc Location");
        Debug.Log(npcLocation);
        healthBar.transform.position = new Vector3(npcLocation.x * 68 + 212, npcLocation.y * 69 + 50, npcLocation.z);
        Debug.Log(healthBar.transform.position);
    }
}
