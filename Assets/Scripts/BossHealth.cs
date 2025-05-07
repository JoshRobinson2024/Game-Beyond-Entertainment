using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public GameObject Boss;
    public Image HealthBar;
    public float maxHealth = 500;
    public float health = 500;
    public float Agression = 0;
    public AudioClip DamageSound;
    public AudioSource DamageSoundPlayer;
    public AudioSource WinTheme;
    public AudioClip WinThemeCLip;
    
    public DialogueController dialogue;
    public PlayerMovement mov;
    public Spawner spawner;
    public bool phase3;
    public bool firstBoss;
    public static bool victory = false;
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
    public void victorySequence()
    {
        if (!victory)
        {
            victory = true;
            mov.BossSound.Stop();
            WinTheme.PlayOneShot(WinThemeCLip);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !mov.isDead)
        {
            if (firstBoss)
            {
                health = 1;
            }
            else 
            {
                spawner.enabled = false;
                victorySequence();
            }
            
        }
        if (health / maxHealth <= 0.8f && !dialogue.phaseChange && !firstBoss)
        {
            dialogue.phaseChange = true;
            dialogue.startDialogue();
            Spawner.phase2 = true;

        }
        if (health / maxHealth <= 0.25f && !phase3 && !firstBoss)
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
        if (!mov.isDead)
        {
            Debug.Log("Lose health");
            health -= strength;
            HealthBar.fillAmount = health / maxHealth;
            Agression += 1;
            DamageSoundPlayer.PlayOneShot(DamageSound);
        }
        
    }
    
}
