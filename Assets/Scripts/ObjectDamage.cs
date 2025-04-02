using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDamage : MonoBehaviour
{
    public bool Damaging = false;
    public BossHealth health;
    public static int Strength;
    public static float Controllerhealth;
    public Color damagingColour;
    public SpriteRenderer rend;
    public Color neutralColour;
    public Image HealthBar;
    public float currentControllerHealth;

    private void Start()
    {
        Controllerhealth = 5;
        currentControllerHealth = Controllerhealth;
        rend = GetComponent<SpriteRenderer>();
        Strength = 500;
    }
    
    public void ControllerDamage()
    {
        Damaging = true;
        rend.color = damagingColour;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Damaging && collision.gameObject.CompareTag("Boss"))
        {
            
            Debug.Log("hit");
            LoseHealth(1);
            Damaging = false;
            rend.color = neutralColour;
            health.damage(Strength);
        }
        
        
        else if (Damaging && collision.gameObject.CompareTag("Wall"))
        {
            
            Debug.Log("hit");
            LoseHealth(1);
            Damaging = false;
            rend.color = neutralColour;
        }
        
    }
    public void gainStrength(int strengthToGain)
    {
        Strength += strengthToGain;
    }
    public void LoseHealth(int damage)
    {
        currentControllerHealth -= damage;
        HealthBar.fillAmount = currentControllerHealth / Controllerhealth;
        
    }
}
