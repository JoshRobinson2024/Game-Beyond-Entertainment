using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarDamage : MonoBehaviour
{
    public bool Damaging = false;
    public BossHealth health;
    public static int guitarStrength;
    public Color damagingColour;
    public SpriteRenderer rend;
    public Color neutralColour;

    private void Start()
    {
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
        }
        Damaging = false;
        rend.color = neutralColour;
    }
    public void GainGuitarStrangth(int guitarStrengthtoGain)
    {
        guitarStrength += guitarStrengthtoGain;
    }
}
