using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public GameObject Boss;
    public Image HealthBar;
    public float maxHealth = 5000;
    public float health = 5000;
    public float Agression = 0;
    void Start()
    {
        health = maxHealth;
        Agression = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(Boss);
        }
    }
    public void damage(int strength)
    {
        Debug.Log("Lose health");
        health -= strength;
        HealthBar.fillAmount = health / maxHealth;
        Agression += 1;
    }
    
}
