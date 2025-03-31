using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarDamage : MonoBehaviour
{
    public bool Damaging = false;
    public BossHealth health;
    public static int guitarStrength;

    public void GDamage()
    {
        Damaging = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Damaging && collision.gameObject.CompareTag("Boss"))
        {
            health.damage(guitarStrength);
            Debug.Log("hit");
        }
        Damaging = false;
    }
    public void GainGuitarStrangth(int guitarStrengthtoGain)
    {
        guitarStrength += guitarStrengthtoGain;
    }
}
