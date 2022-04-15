using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatAI : MonoBehaviour
{
    float health;
    float maxHealth;

    Vector3 barLocation;

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
}
