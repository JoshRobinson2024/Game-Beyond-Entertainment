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
    private void Start()
    {
        Journalhealth = 5;
        currentJournalHealth = Journalhealth;
        rend = GetComponent<SpriteRenderer>();
        journalStrength = 250;
    }
    public void JDamage()
    {
        Damaging = true;
        rend.color = damagingColour;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Damaging && collision.gameObject.CompareTag("Boss"))
        {
            health.damage(journalStrength);
            Debug.Log("hit");
            LoseHealth(1);
            health.damage(journalStrength);
        }
        else if (Damaging && collision.gameObject.CompareTag("Wall"))
        {

            Debug.Log("hit");
            LoseHealth(1);
        }
        Damaging = false;
        
        rend.color = neutralColour;
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
