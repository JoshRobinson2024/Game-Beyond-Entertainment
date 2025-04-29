using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public GameObject Boss;
    public Image HealthBar;
    public float maxHealth = 5000;
    public float health = 5000;
    public float Agression = 0;
    public AudioClip DamageSound;
    public AudioSource DamageSoundPlayer;
    public DialogueController dialogue;
    public PlayerMovement mov;
    public bool phase3;
    void Start()
    {
        dialogue.Death = false;
        dialogue.Final = false;
        phase3 = false;
        dialogue.phaseChange = false;
        health = maxHealth;
        Agression = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(Boss);
        }
        if (health / maxHealth <= 0.8f && !dialogue.phaseChange)
        {
            dialogue.phaseChange = true;
            dialogue.startDialogue();

        }
        if (health / maxHealth <= 0.6f && !phase3)
        {
            phase3 = true;
            dialogue.startDialogue();
        }
        if (health / maxHealth <= 0.4f && !dialogue.Final)
        {
            dialogue.Final = true;
            dialogue.startDialogue();
        }
        if (mov.isDead && !dialogue.Death)
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
