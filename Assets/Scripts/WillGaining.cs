using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WillGaining : MonoBehaviour
{
    public static float WillAmount;
    public float TimeSurvived;
    public float DamageDealt;
    public BossHealth BossHealth;
    public static float WillDisplay;
    public static float SecondsSurvived;
    public static float DamageDone;
    public static float Aggression;
    public static float WillGained;
    
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
    public void calculateDisplay()
    {
        CancelInvoke("CountTime");
        TimeSurvived = Mathf.Floor(TimeSurvived * 1) / 1;
        DamageDealt = Mathf.Floor(DamageDealt * 1) / 1;
        BossHealth.Agression = Mathf.Floor(BossHealth.Agression * 1) / 1;
        SecondsSurvived = TimeSurvived;
        DamageDone = DamageDealt;
        Aggression = BossHealth.Agression;
        calculateWill();
    }
    public void calculateWill()
    {
        

        
        DamageDealt /= 50;
        BossHealth.Agression /= 3;
        TimeSurvived /= 30;

        /*Mathf.FloorToInt(TimeSurvived);
        Mathf.FloorToInt(DamageDealt);
        Mathf.FloorToInt(BossHealth.Agression);*/
        TimeSurvived = Mathf.Floor(TimeSurvived*1) / 1;
        DamageDealt = Mathf.Floor(DamageDealt * 1) / 1;
        BossHealth.Agression = Mathf.Floor(BossHealth.Agression * 1) / 1;
        Debug.Log(TimeSurvived);
        Debug.Log(DamageDealt);
        Debug.Log(BossHealth.Agression);
        if (TimeSurvived >= DamageDealt && TimeSurvived >= BossHealth.Agression)
        {
            WillAmount += DamageDealt + BossHealth.Agression;
            WillGained = DamageDealt + BossHealth.Agression;
            Debug.Log(WillAmount);
            Debug.Log("Ignore time");
        }
        else if(TimeSurvived <= DamageDealt && BossHealth.Agression <= DamageDealt)
        {
            WillAmount += TimeSurvived + BossHealth.Agression;
            WillGained = TimeSurvived + BossHealth.Agression;
            Debug.Log("Ignore Damage");
            Debug.Log(WillAmount);
        }
        else if (TimeSurvived <= BossHealth.Agression && BossHealth.Agression >= DamageDealt)
        {
            WillAmount += TimeSurvived + DamageDealt;
            WillGained = TimeSurvived + DamageDealt;
            Debug.Log(WillAmount);
            Debug.Log("IgnoreAgression");
        }
        else
        {
            Debug.Log("Failsafe");
            WillAmount += 3;
            WillGained = 3;
        }
        WillAmount += 1;
        WillGained += 1;
        Mathf.Round(WillAmount);
        if (WillAmount > 99)
        {
            WillAmount = 99;
        }
        if (WillGained > 99)
        {
            WillGained = 99;
        }
        Debug.Log(WillAmount);
        
    }
}
