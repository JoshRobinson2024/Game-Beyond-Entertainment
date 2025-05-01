using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDialogueTriggers : MonoBehaviour
{
    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;
    public GameObject trigger4;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public FirstDialogueController controller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Trigger1"))
        {
            Destroy(trigger1);
            controller.index = 0;
            controller.NextLine();
            wall1.SetActive(true);

        }

        if (collision.gameObject.name.Equals("Trigger2"))
        {
            Destroy(trigger2);
            controller.index = 1;
            controller.NextLine();
            wall2.SetActive(true);
        }
        else if (collision.gameObject.name.Equals("Trigger3"))
        {
            Destroy(trigger3);
            controller.index = 2;
            controller.NextLine();
            wall3.SetActive(true);
            
        }
        else if (collision.gameObject.name.Equals("Trigger4"))
        {
            Destroy(trigger4);
            controller.index = 3;
            controller.NextLine();
            wall4.SetActive(true);

        }
    }

}
