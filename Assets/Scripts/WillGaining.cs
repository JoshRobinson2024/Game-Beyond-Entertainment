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
        DamageDealt /= 50;
        BossHealth.Agression /= 3;
        TimeSurvived /= 30;
        Mathf.Floor(TimeSurvived);
        Mathf.Floor(DamageDealt);
        Mathf.Floor(BossHealth.Agression);
        Debug.Log(TimeSurvived);
        Debug.Log(DamageDealt);
        Debug.Log(BossHealth.Agression);
        if (TimeSurvived >= DamageDealt && TimeSurvived >= BossHealth.Agression)
        {
            WillAmount += DamageDealt * BossHealth.Agression;
            Debug.Log(WillAmount);
            Debug.Log("Ignore time");
        }
        else if(TimeSurvived <= DamageDealt && BossHealth.Agression <= DamageDealt)
        {
            WillAmount += TimeSurvived * BossHealth.Agression;
            Debug.Log("Ignore Damage");
            Debug.Log(WillAmount);
        }
        else if (TimeSurvived <= BossHealth.Agression && BossHealth.Agression >= DamageDealt)
        {
            WillAmount += TimeSurvived * DamageDealt;
            Debug.Log(WillAmount);
            Debug.Log("IgnoreAgression");
        }
        else
        {
            Debug.Log("Failsafe");
            WillAmount += 3;
        }
        WillAmount += 1;
        
    }
}
