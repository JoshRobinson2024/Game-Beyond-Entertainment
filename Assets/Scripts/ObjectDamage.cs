using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamage : MonoBehaviour
{
    public bool Damaging = false;
    public BossHealth health;
    
    public void ControllerDamage()
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
