using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
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
    public int ControllerHealthMax = 4;
    public int GuitarHealthMax = 6;
    public int JournalHealthMax = 8;
    
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
    public TMP_Text ControllerHealthNotEnoughtext;
    public TMP_Text GuitarhealthNotEnoughText;
    public TMP_Text JournalhealthnotEnoughtext;
    public TMP_Text HealthAndDefenseNotEnoughText;
    public TMP_Text ControllerHealthMaxText;
    public TMP_Text GuitarHealthMaxText;
    public TMP_Text JournalHealthMaxText;
    public TMP_Text DoubleJournalHealthMaxText;
    
    public Button DreamJournalButton;
    public Button gamesButton;
    public Button guitarButton;
    public Button journalButton;
    public Button gamesHealthButton;
    public Button guitarHealthButton;
    public Button journalHealthButton;
    public Button healthAndDefenseButton;
    public Button DoubleJournalHealthbutton;
    public Image will1;
    public Image will2;
    public Image will3;
    public Image will4;
    // Start is called before the first frame update
    private void Start()
    {

        
        
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
        if (ObjectDamage.Controllerhealth >= ControllerHealthMax)
        {
            will1.enabled = false;
            ControllerHealthCostText.enabled = false;
            ControllerHealthNotEnoughtext.enabled = false;
            ControllerHealthMaxText.enabled = true;
            gamesHealthButton.enabled = false;
        }
        else if (ControllerHealthCost > WillGaining.WillAmount)
        {
            will1.enabled = true;
            ControllerHealthCostText.enabled = true;
            ControllerHealthMaxText.enabled = false;
            ControllerHealthNotEnoughtext.enabled = true;
            gamesHealthButton.enabled = false;
        }
        else
        {
            will1.enabled = true;
            ControllerHealthCostText.enabled = true;
            ControllerHealthMaxText.enabled = false;
            ControllerHealthNotEnoughtext.enabled= false;
            gamesHealthButton.enabled = true;
        }
        if (GuitarDamage.Guitarhealth >= GuitarHealthMax)
        {
            will2.enabled = false;
            GuitarHealthCostText.enabled = false;
            GuitarhealthNotEnoughText.enabled = false;
            GuitarHealthMaxText.enabled = true;
            guitarHealthButton.enabled = false;
        }
        else if (GuitarHealthCost > WillGaining.WillAmount)
        {
            will2.enabled = true;
            GuitarHealthCostText.enabled = true;
            GuitarHealthMaxText.enabled = false;
            GuitarhealthNotEnoughText.enabled = true;
            guitarHealthButton.enabled = false;
        }
        else
        {
            will2.enabled = false;
            GuitarHealthCostText.enabled= false;
            GuitarHealthMaxText.enabled = false;
            GuitarhealthNotEnoughText.enabled = false;
            guitarHealthButton.enabled = true;
        }
        if (JournalDamage.Journalhealth >= JournalHealthMax)
        {
            will3.enabled = false;
            JournalHealthCostText.enabled = false;
            JournalhealthnotEnoughtext.enabled = false;
            DoubleJournalHealthMaxText.enabled = true;
            will4.enabled = false;
            DoubleJournalHealthCostText.enabled = false;
            JournalHealthMaxText.enabled = true;
            journalHealthButton.enabled = false;
            DoubleJournalHealthbutton.enabled = false;
        }
        else if (JournalHealthCost > WillGaining.WillAmount)
        {
            
            DoubleJournalHealthMaxText.enabled = false;
            will4.enabled = true;
            DoubleJournalHealthCostText.enabled = true;
            will2.enabled = true;
            JournalHealthCostText.enabled = true;
            JournalHealthMaxText.enabled = false;
            JournalhealthnotEnoughtext.enabled = true;
            journalHealthButton.enabled = false;
        }
        else
        {
            
            DoubleJournalHealthMaxText.enabled = false;
            will4.enabled = true;
            DoubleJournalHealthCostText.enabled = true;
            will3.enabled = true;
            JournalHealthCostText.enabled = true;
            JournalHealthMaxText.enabled = false;
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
        if (JournalDamage.Journalhealth >= JournalHealthMax)
        {
            DoubleJournalHealthbutton.enabled = false;
            DoubleJournalHealthNotEnoughText.enabled = false;
        }
        else if (DoubleJournalHealthCost > WillGaining.WillAmount)
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
            HealthAndDefenseCost += 3;
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
