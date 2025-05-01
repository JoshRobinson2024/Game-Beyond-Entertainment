using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDialogueTriggers : MonoBehaviour
{
    
    public GameObject trigger2;
    public GameObject trigger3;
    public FirstDialogueController controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name.Equals("Trigger2"))
        {
            Destroy(trigger2);
            controller.NextLine();
        }
        else if (collision.gameObject.name.Equals("Trigger3"))
        {
            Destroy(trigger3);
            controller.NextLine();
        }
    }

}
