using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WillDIsplay : MonoBehaviour
{
    public TMP_Text WillText;
    
    
       
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WillText.text = "X " + WillGaining.WillAmount.ToString();
    }
    

}
