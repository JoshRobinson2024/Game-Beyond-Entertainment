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
    public void gainHealth(int healthToGain)
    {
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
    public void gainGuitar(int guitarToGain)
    {
        GuitarDamage.guitarStrength += guitarToGain;
    }
    public void gainJournal(int journalToGain)
    {
        JournalDamage.journalStrength += journalToGain;
    }
}
