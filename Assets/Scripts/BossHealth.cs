using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public GameObject Boss;
    public Image HealthBar;
    public float maxHealth = 1000;
    public float health = 1000;
    public float Agression = 0;
    public AudioClip DamageSound;
    public AudioSource DamageSoundPlayer;
    public DialogueController dialogue;
    public PlayerMovement mov;
    public bool phase3;
    public bool firstBoss;
    void Start()
    {
        if (!firstBoss) 
        {
            dialogue.Death = false;
            dialogue.Final = false;
            phase3 = false;
            dialogue.phaseChange = false;
            health = maxHealth;
            Agression = 0;
        }
        else if (firstBoss) 
        {
            health = 5000;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (firstBoss)
            {
                health = 1;
            }
            else 
            {
                Destroy(Boss);
            }
            
        }
        if (health / maxHealth <= 0.8f && !dialogue.phaseChange && !firstBoss)
        {
            dialogue.phaseChange = true;
            dialogue.startDialogue();
            Spawner.phase2 = true;

        }
        if (health / maxHealth <= 0.5f && !phase3 && !firstBoss)
        {
            phase3 = true;
            dialogue.startDialogue();
            Spawner.phase3 = true;
        }
        if (health / maxHealth <= 0.1f && !dialogue.Final && !firstBoss)
        {
            dialogue.Final = true;
            dialogue.startDialogue();
            Spawner.furyMode = true;
        }
        if (mov.isDead && !dialogue.Death && !firstBoss)
        {
            dialogue.Death = true;
            dialogue.startDialogue();
        }

    }
    public void damage(int strength)
    {
        Debug.Log("Lose health");
        health -= strength;
        HealthBar.fillAmount = health / maxHealth;
        Agression += 1;
        DamageSoundPlayer.PlayOneShot(DamageSound);
    }
    
}
