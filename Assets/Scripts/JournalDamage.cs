using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalDamage : MonoBehaviour
{
    public bool Damaging = false;
    public BossHealth health;

    public void JDamage()
    {
        Damaging = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Damaging && collision.gameObject.CompareTag("Boss"))
        {
            health.damage(100);
            Debug.Log("hit");
        }
        Damaging = false;
    }
}
