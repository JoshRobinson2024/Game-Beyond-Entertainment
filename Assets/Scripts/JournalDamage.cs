using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalDamage : MonoBehaviour
{
    public BoxCollider2D BoxCollider2D;

    public void JDamage()
    {
        BoxCollider2D.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoxCollider2D.GetComponent<BoxCollider2D>().enabled = false;
    }
}
