using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathInfo : MonoBehaviour
{
    public TMP_Text DamageText;
    public TMP_Text AggressionText;
    public TMP_Text SecondsText;
    public TMP_Text WillText;
    public TMP_Text TotalWillText;
    private void Start()
    {
        TextUpdate();
    }
    public void TextUpdate()
    {
        DamageText.text = "Damage: " + WillGaining.DamageDone.ToString();
        AggressionText.text = "Aggression: " + WillGaining.Aggression.ToString();
        SecondsText.text = "Seconds alive: " + WillGaining.SecondsSurvived.ToString();
        WillText.text = "Will gained: " + WillGaining.WillGained.ToString();
        TotalWillText.text = "X " + WillGaining.WillAmount.ToString();
    }



}
