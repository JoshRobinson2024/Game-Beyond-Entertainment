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
    public float journalGuitarHealth;
    public static float Journalhealth;
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
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
        }
        Damaging = false;
        rend.color = neutralColour;
    }
    public void journalStrengthGain(int journalStrengthtoGain)
    {
        journalStrength += journalStrengthtoGain;
    }
}
