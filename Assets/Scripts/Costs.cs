using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Costs : MonoBehaviour
{
    public static int GamesCost;
    public static int GuitarCost;
    public static int JournalCost;
    public static int ControllerHealthCost;
    public static int GuitarHealthCost;
    public static int JournalHealthCost;
    public static int HealthAndDefenseCost;
    public static int DreamJournalCost;
    public static int DoubleJournalHealthCost;
    public TMP_Text DoubleJournalHealthCostText;
    public TMP_Text DreamJournalCostText;
    public TMP_Text GamesCostText;
    public TMP_Text GuitarCostText;
    public TMP_Text JournalCostText;
    public TMP_Text ControllerHealthCostText;
    public TMP_Text GuitarHealthCostText;
    public TMP_Text JournalHealthCostText;
    public TMP_Text HealthAndDefenseCostText;
    public TMP_Text DoubleJournalHealthNotEnoughText;
    public TMP_Text DreamJournalNotEnoughText;
    public TMP_Text GamesNotEnoughText;
    public TMP_Text GuitarNotEnoughText;
    public TMP_Text JournalNotEnoughText;
    public TMP_Text GamesHealthNotEnoughtext;
    public TMP_Text GuitarhealthNotEnoughText;
    public TMP_Text JournalhealthnotEnoughtext;
    public TMP_Text HealthAndDefenseNotEnoughText;
    public Button DreamJournalButton;
    public Button gamesButton;
    public Button guitarButton;
    public Button journalButton;
    public Button gamesHealthButton;
    public Button guitarHealthButton;
    public Button journalHealthButton;
    public Button healthAndDefenseButton;
    public Button DoubleJournalHealthbutton;
    
    // Start is called before the first frame update
    private void Start()
    {
        WillGaining.WillAmount = 1;
        
    }
    private void Update()
    {
        DreamJournalCost = (JournalCost * 2);
        if(DreamJournalCost <= 0)
        {
            DreamJournalCost = 0;
        }
        DoubleJournalHealthCost = 2;
        GamesCostText.text = "- " + GamesCost.ToString();
        GuitarCostText.text = "- " + GuitarCost.ToString();
        JournalCostText.text = "- " + JournalCost.ToString();
        ControllerHealthCostText.text = "- " + ControllerHealthCost.ToString();
        GuitarHealthCostText.text = "- " + GuitarHealthCost.ToString();
        JournalHealthCostText.text = "- " + JournalHealthCost.ToString();
        HealthAndDefenseCostText.text = "- " + HealthAndDefenseCost.ToString();
        DreamJournalCostText.text = "- " + DreamJournalCost.ToString();
        DoubleJournalHealthCostText.text = "- " + DoubleJournalHealthCost.ToString();
        if (GamesCost > WillGaining.WillAmount)
        {
            GamesNotEnoughText.enabled = true;
            gamesButton.enabled = false;
        }
        else
        {
            GamesNotEnoughText.enabled = false;
            gamesButton.enabled = true;
        }
        if (GuitarCost > WillGaining.WillAmount)
        {
            GuitarNotEnoughText.enabled = true;
            guitarButton.enabled = false;
        }
        else
        {
            GuitarNotEnoughText.enabled= false;
            guitarButton.enabled = true;
        }
        if (JournalCost > WillGaining.WillAmount)
        {
            JournalNotEnoughText.enabled = true;
            journalButton.enabled = false;
        }
        else
        {
            JournalNotEnoughText.enabled= false;
            journalButton.enabled = true;
        }
        if (ControllerHealthCost > WillGaining.WillAmount)
        {
            GamesHealthNotEnoughtext.enabled = true;
            gamesHealthButton.enabled = false;
        }
        else
        {
            GamesHealthNotEnoughtext.enabled= false;
            gamesHealthButton.enabled = true;
        }
        if (GuitarHealthCost > WillGaining.WillAmount)
        {
            GuitarhealthNotEnoughText.enabled = true;
            guitarHealthButton.enabled = false;
        }
        else
        {
            GuitarhealthNotEnoughText.enabled = false;
            guitarHealthButton.enabled = true;
        }
        if (JournalHealthCost > WillGaining.WillAmount)
        {
            JournalhealthnotEnoughtext.enabled = true;
            journalHealthButton.enabled = false;
        }
        else
        {
            JournalhealthnotEnoughtext.enabled= false;
            journalHealthButton.enabled = true;
        }
        if (HealthAndDefenseCost > WillGaining.WillAmount)
        {
            HealthAndDefenseNotEnoughText.enabled = true;
            healthAndDefenseButton.enabled = false;
        }
        else
        {
            HealthAndDefenseNotEnoughText.enabled = false;
            healthAndDefenseButton.enabled = true;
        }
        if (DreamJournalCost > WillGaining.WillAmount)
        {
            DreamJournalNotEnoughText.enabled = true;
            DreamJournalButton.enabled = false;
        }
        else
        {
            DreamJournalNotEnoughText.enabled = false;
            DreamJournalButton.enabled = true;
        }
        if (DoubleJournalHealthCost > WillGaining.WillAmount)
        {
            DoubleJournalHealthNotEnoughText.enabled = true;
            DoubleJournalHealthbutton.enabled = false;
        }
        else
        {
            DoubleJournalHealthNotEnoughText.enabled = false;
            DoubleJournalHealthbutton.enabled = true;
        }
    }
    public void SubtractWill(Button button)
    {
        if (button == gamesButton)
        {
            WillGaining.WillAmount -= GamesCost;
            GamesCost += 1;
        }
        else if (button == guitarButton) 
        {
            WillGaining.WillAmount -= GuitarCost;
            GuitarCost += 1;
        }
        else if(button == journalButton)
        {
            WillGaining.WillAmount -= JournalCost;
            JournalCost += 1;
        }
        else if(button == gamesHealthButton)
        {
            WillGaining.WillAmount -= ControllerHealthCost;
            
        }
        else if( button == guitarHealthButton)
        {
            WillGaining.WillAmount -= GuitarHealthCost;
            
        }
        else if(button == journalHealthButton)
        {
            WillGaining.WillAmount -= JournalHealthCost;
            
        }
        else if(button == healthAndDefenseButton)
        {
            WillGaining.WillAmount -= HealthAndDefenseCost;
            HealthAndDefenseCost += 2;
        }
        else if (button == DreamJournalButton)
        {
            WillGaining.WillAmount -= DreamJournalCost;
            JournalCost += 1;  
        }
        else if (button == DoubleJournalHealthbutton)
        {
            WillGaining.WillAmount -= DoubleJournalHealthCost;

        }
    }
    

}
