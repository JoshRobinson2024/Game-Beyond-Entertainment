using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamage : MonoBehaviour
{
    public bool Damaging = false;
    public BossHealth health;
    public static int Strength;
    public Color damagingColour;
    public SpriteRenderer rend;
    public Color neutralColour;

    private void Start()
    {
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
    }
    public void gainStrength(int strengthToGain)
    {
        Strength += strengthToGain;
    }
}
