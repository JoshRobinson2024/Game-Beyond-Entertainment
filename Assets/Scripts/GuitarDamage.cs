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
    public Color brokenColour;
    public static bool GuitarGrabbable = true;
    public ObjectDamage CDamage;
    public JournalDamage JDamage;

    public TrailRenderer TrailRenderer;

    private void Start()
    {
        Guitarhealth = 5;
        currentGuitarHealth = Guitarhealth;
        rend = GetComponent<SpriteRenderer>();
        guitarStrength = 250;
        TrailRenderer.emitting = false;
    }
    public void GDamage()
    {
        Damaging = true;
        rend.color = damagingColour;
        TrailRenderer.emitting = true;
    }
    public void heal()
    {
        if (currentGuitarHealth < Guitarhealth)
        {
            currentGuitarHealth += 1;
            HealthBar.fillAmount = currentGuitarHealth / Guitarhealth;
            if (currentGuitarHealth == Guitarhealth)
            {
                rend.color = neutralColour;
                GuitarGrabbable = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Damaging && collision.gameObject.CompareTag("Boss") && currentGuitarHealth > 2)
        {
            health.damage(guitarStrength);
            Debug.Log("hit");
            LoseHealth(1);
            health.damage(guitarStrength);
            CDamage.heal();
            JDamage.heal();
        }
        else if (Damaging && collision.gameObject.CompareTag("Boss") && currentGuitarHealth == 2)
        {
            Debug.Log("hit");
            LoseHealth(1);
            Damaging = false;
            rend.color = neutralColour;
            health.damage(guitarStrength / 2);
            CDamage.heal();
            JDamage.heal();
        }
        else if (Damaging && collision.gameObject.CompareTag("Boss") && currentGuitarHealth == 1)
        {
            Debug.Log("hit");
            LoseHealth(1);
            Damaging = false;
            rend.color = neutralColour;
            health.damage(guitarStrength / 4);
            CDamage.heal();
            JDamage.heal();
        }
        else if (Damaging && collision.gameObject.CompareTag("Wall"))
        {

            Debug.Log("hit");
            LoseHealth(1);
            CDamage.heal();
            JDamage.heal();
        }
        Damaging = false;
        rend.color = neutralColour;
        if (currentGuitarHealth == 0)
        {
            GuitarGrabbable = false;
            rend.color = brokenColour;
        }
        TrailRenderer.emitting = false;
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
