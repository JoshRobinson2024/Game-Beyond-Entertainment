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
    private Vector2 GuitarRespawnPos;
    public TrailRenderer TrailRenderer;
    public GameObject Guitar;
    private bool broken;
    private void Start()
    {
        GuitarRespawnPos = Guitar.transform.position;
        
        currentGuitarHealth = Guitarhealth;
        rend = GetComponent<SpriteRenderer>();
        
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
                broken = false;
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
        if (collision.gameObject.CompareTag("OutOfBounds"))
        {

            Debug.Log("hit");
            LoseHealth(1);
            Damaging = false;
            rend.color = neutralColour;
            Guitar.transform.position = GuitarRespawnPos;
            CDamage.heal();
            JDamage.heal();
        }
        if (!broken)
        {
            
            rend.color = neutralColour;
        }
        Damaging = false;
        if (currentGuitarHealth == 0)
        {
            broken = true;
            GuitarGrabbable = false;
            rend.color = brokenColour;
            DialogueController.broken = true;
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
