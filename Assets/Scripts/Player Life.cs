using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public static int maxHealth;
    public static int defense;
    public float currentHealth;
    public float healthToLose;
    public bool iFrames = false;
    private void Start()
    {
        currentHealth = maxHealth;
        healthToLose = 10 - defense;
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
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
