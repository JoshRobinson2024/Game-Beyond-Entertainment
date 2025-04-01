using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuitarDamage : MonoBehaviour
{
    public bool Damaging = false;
    public BossHealth health;
    public static int guitarStrength;
    public Color damagingColour;
    public SpriteRenderer rend;
    public Color neutralColour;
    public Image HealthBar;
    public float currentGuitarHealth;
    public static float Guitarhealth;
    private void Start()
    {
        Guitarhealth = 5;
        currentGuitarHealth = Guitarhealth;
        rend = GetComponent<SpriteRenderer>();
    }
    public void GDamage()
    {
        Damaging = true;
        rend.color = damagingColour;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Damaging && collision.gameObject.CompareTag("Boss"))
        {
            health.damage(guitarStrength);
            Debug.Log("hit");
            LoseHealth(1);
        }
        else if (Damaging && collision.gameObject.CompareTag("Wall"))
        {

            Debug.Log("hit");
            LoseHealth(1);
        }
        Damaging = false;
        rend.color = neutralColour;
    }
    public void GainGuitarStrangth(int guitarStrengthtoGain)
    {
        guitarStrength += guitarStrengthtoGain;
    }
    public void LoseHealth(int damage)
    {
        currentGuitarHealth -= damage;
        HealthBar.fillAmount = currentGuitarHealth / Guitarhealth;
        rend.color = neutralColour; ;
    }
}
