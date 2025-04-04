using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarolourChange : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public BossHealth BHealth;
    public ObjectDamage ObjectDamage;
    public GuitarDamage GuitarDamage;
    public JournalDamage JournalDamage;
    public Image ControllerBar;
    public Image GuitarBar;
    public Image JournalBar;
    public Image BossBar;
    public Image PlayerBar;
    public Color playernatural;
    public Color playerlow;
    public Color bossNatural;
    public Color bossLow;
    public Color natural;
    
    public Color low;
    
    public float BossDifference;
    public float playerDifference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BossDifference = BHealth.health / BHealth.maxHealth;
        if (PlayerMovement.currentHealth / PlayerMovement.maxHealth <= 0.33f)
        {
            PlayerBar.color = playerlow;
        }

        if (BossDifference <= 0.33f)
        {
            BossBar.color = bossLow;
        }

        if (ObjectDamage.currentControllerHealth == 1)
        {
            ControllerBar.color = low;
        }
        else if (ObjectDamage.Grabbable == false)
        {
            ControllerBar.color = low;
        }
        else
        {
            ControllerBar.color = natural;
        }
        
        if (GuitarDamage.currentGuitarHealth == 1)
        {
            GuitarBar.color = low;
        }
        else if (GuitarDamage.GuitarGrabbable == false)
        {
            GuitarBar.color = low;
        }
        else
        {
            GuitarBar.color = natural;
        }

        if (JournalDamage.currentJournalHealth == 1)
        {
            JournalBar.color = low;
        }
        else if (JournalDamage.JournalGrabbable == false)
        {
            JournalBar.color = low;
        }
        else
        {
            JournalBar.color = natural;
        }
    }
}
