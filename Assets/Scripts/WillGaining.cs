using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillGaining : MonoBehaviour
{
    public static float WillAmount;
    public float TimeSurvived;
    public float DamageDealt;
    public BossHealth BossHealth;

    private void Start()
    {
        InvokeRepeating("CountTime", 0, 1);
    }
    private void Update()
    {
        DamageDealt = BossHealth.maxHealth - BossHealth.health;
    }
    public void CountTime()
    {
        TimeSurvived += 1;
    }
    public void calculateWill()
    {
        if (TimeSurvived >= DamageDealt)
        {
            WillAmount += DamageDealt;
        }
        else if(TimeSurvived < DamageDealt)
        {
            WillAmount += TimeSurvived;
        }
    }
}
