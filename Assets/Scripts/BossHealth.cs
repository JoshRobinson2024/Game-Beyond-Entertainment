using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Image HealthBar;
    private float maxHealth = 5000;
    public float health = 5000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void damage(int strength)
    {
        Debug.Log("Lose health");
        health -= strength;
        HealthBar.fillAmount = health / maxHealth;
        
    }
    
}
