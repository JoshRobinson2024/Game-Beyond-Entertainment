using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalDamage : MonoBehaviour
{
    public bool Damaging = false;
    public BossHealth health;
    public static int journalStrength;
    public Color damagingColour;
    public SpriteRenderer rend;
    public Color neutralColour;
    public Image HealthBar;
    public float currentJournalHealth;
    public static float Journalhealth;
    
    public Color brokenColour;
    public static bool JournalGrabbable = true;
    public ObjectDamage CDamage;
    public GuitarDamage GDamage;
    private Vector2 JournalRespawnPos;
    public TrailRenderer TrailRenderer;
    public GameObject Journal;
    private bool broken;
    private void Start()
    {
        JournalRespawnPos = Journal.transform.position;
        
        currentJournalHealth = Journalhealth;
        rend = GetComponent<SpriteRenderer>();
        
        TrailRenderer.emitting = false;
    }
    public void JDamage()
    {
        Damaging = true;
        rend.color = damagingColour;
        TrailRenderer.emitting = true;
    }
    public void heal()
    {
        if (currentJournalHealth < Journalhealth)
        {
            currentJournalHealth += 1;
            HealthBar.fillAmount = currentJournalHealth / Journalhealth;
            if (currentJournalHealth == Journalhealth)
            {
                broken = false;
                rend.color = neutralColour;
                JournalGrabbable = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Damaging && collision.gameObject.CompareTag("Boss") && currentJournalHealth > 2)
        {
            health.damage(journalStrength);
            Debug.Log("hit");
            LoseHealth(1);
            health.damage(journalStrength);
            CDamage.heal();
            GDamage.heal();
        }
        else if (Damaging && collision.gameObject.CompareTag("Boss") && currentJournalHealth == 2)
        {
            Debug.Log("hit");
            LoseHealth(1);
            Damaging = false;
            rend.color = neutralColour;
            health.damage(journalStrength / 2);
            CDamage.heal();
            GDamage.heal();
        }
        else if (Damaging && collision.gameObject.CompareTag("Boss") && currentJournalHealth == 1)
        {
            Debug.Log("hit");
            LoseHealth(1);
            Damaging = false;
            rend.color = neutralColour;
            health.damage(journalStrength / 4);
            CDamage.heal();
            GDamage.heal();
        }
        else if (Damaging && collision.gameObject.CompareTag("Wall"))
        {

            Debug.Log("hit");
            LoseHealth(1);
            CDamage.heal();
            GDamage.heal();
        }
        if (collision.gameObject.CompareTag("OutOfBounds"))
        {

            Debug.Log("hit");
            LoseHealth(1);
            Damaging = false;
            rend.color = neutralColour;
            Journal.transform.position = JournalRespawnPos;
            GDamage.heal();
            CDamage.heal();
        }
        Damaging = false;
        if (!broken)
        {
            rend.color = neutralColour;
        }
        
        if (currentJournalHealth == 0)
        {
            broken = true;
            JournalGrabbable = false;
            rend.color = brokenColour;
            DialogueController.broken = true;
        }
        TrailRenderer.emitting = false;
    }
    public void journalStrengthGain(int journalStrengthtoGain)
    {
        journalStrength += journalStrengthtoGain;
    }
    public void LoseHealth(int damage)
    {
        currentJournalHealth -= damage;
        HealthBar.fillAmount = currentJournalHealth / Journalhealth;
        rend.color = neutralColour; ;
    }
}
