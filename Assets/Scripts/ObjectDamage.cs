using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDamage : MonoBehaviour
{
    public bool Damaging = false;
    public BossHealth health;
    public static int Strength;
    public static int Controllerhealth;
    public Color damagingColour;
    public SpriteRenderer rend;
    public Color neutralColour;
    public Image HealthBar;
    private int currentControllerHealth;

    private void Start()
    {
        Controllerhealth = 5;
        currentControllerHealth = Controllerhealth;
        rend = GetComponent<SpriteRenderer>();
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
            health.damage(Strength);
            Debug.Log("hit");
        }
        Damaging = false;
        rend.color = neutralColour;
        loseHealth(1);
    }
    public void gainStrength(int strengthToGain)
    {
        Strength += strengthToGain;
    }
    public void loseHealth(int damage)
    {
        currentControllerHealth -= damage;
        HealthBar.fillAmount = currentControllerHealth / Controllerhealth*100;
    }
}
