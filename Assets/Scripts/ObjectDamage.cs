using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamage : MonoBehaviour
{
    public BoxCollider2D BoxCollider2D;
    public BossHealth health;
    
    public void ControllerDamage()
    {
        BoxCollider2D.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoxCollider2D.GetComponent<BoxCollider2D>().enabled = false;
        
    }
}
