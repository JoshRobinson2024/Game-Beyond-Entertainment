using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public float maxHealth;
    public float defense;
    public float currentHealth;
    public float healthToLose;
    public bool iFrames = false;
    private void Start()
    {
        currentHealth = maxHealth;
        healthToLose = 10 - defense;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Bullet"))
        {
            if (iFrames == false)
            {
                iFrames = true;
                currentHealth -= healthToLose;
                Debug.Log(currentHealth.ToString());
                Invoke("loseIFrames", 0.67f);
            }
            
        }
    }
    private void loseIFrames()
    {
        iFrames = false;
    }
}
