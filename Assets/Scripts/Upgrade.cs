using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gainHealth(float healthToGain)
    {
        if(PlayerMovement.defense > 2)
        {
            healthToGain -= 1;
        }
        if (PlayerMovement.defense > 3)
        {
            healthToGain -= 1;
        }
        if (PlayerMovement.defense > 4)
        {
            healthToGain -= 1;
        }
        PlayerMovement.maxHealth += healthToGain;
    }
    public void gainDefense(int defenseToGain)
    {
        PlayerMovement.defense += defenseToGain;
    }
    public void gainController(int controllerToGain)
    {
        ObjectDamage.Strength += controllerToGain;
    }
    public void gainControllerHealth(int healthToGain)
    {
        ObjectDamage.Controllerhealth += healthToGain;
    }
    public void gainGuitar(int guitarToGain)
    {
        GuitarDamage.guitarStrength += guitarToGain;
    }
    public void gainGuitarHealth(int healthToGain)
    {
        GuitarDamage.Guitarhealth += healthToGain;
    }
    public void gainJournal(int journalToGain)
    {
        JournalDamage.journalStrength += journalToGain;
    }
    public void gainJournalHealth(int healthToGain)
    {
        JournalDamage.Journalhealth += healthToGain;
    }
}
