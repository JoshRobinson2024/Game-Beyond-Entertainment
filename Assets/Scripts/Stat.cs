using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public TMP_Text gamesStrength;
    public TMP_Text gamesHealth;
    public TMP_Text guitarStrength;
    public TMP_Text guitarHealth;
    public TMP_Text journalStrength;
    public TMP_Text journalHealth;
    public TMP_Text playerHealth;
    public TMP_Text playerDefense;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gamesStrength.text = "Strength: " + ObjectDamage.Strength.ToString();
        gamesHealth.text = "Health: " + ObjectDamage.Controllerhealth.ToString();
        guitarStrength.text = "Strength: " + GuitarDamage.guitarStrength.ToString();
        guitarHealth.text = "Health: "+ GuitarDamage.Guitarhealth.ToString();
        journalStrength.text = "Strength: " + JournalDamage.journalStrength.ToString();
        journalHealth.text = "Health: " + JournalDamage.Journalhealth.ToString();
        playerHealth.text = "Max HP: " + PlayerMovement.maxHealth.ToString();
        playerDefense.text = "Defense: " + PlayerMovement.defense.ToString();
    }
}
