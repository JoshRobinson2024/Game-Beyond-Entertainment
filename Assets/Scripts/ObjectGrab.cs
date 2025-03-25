using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrab : MonoBehaviour
{
    public GameObject EController;
    public GameObject EGuitar;
    public GameObject EJournal;
    public bool grabbedObject = false;
    public GameObject Controller;
    public GameObject Guitar;
    public GameObject Journal;
    // Start is called before the first frame update
    void Start()
    {
        EController.SetActive(false);
        EGuitar.SetActive(false);
        EJournal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (EController.activeInHierarchy&& Input.GetKeyDown(KeyCode.E))
        {
            grabbedObject = true;
            
        }
        else if(EGuitar.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            grabbedObject = true;
        }
        else if(EJournal.activeInHierarchy&& Input.GetKeyDown(KeyCode.E))
        {
            grabbedObject = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("controller"))
        {
            EController.SetActive(true);

        }
        else if (collision.gameObject.name.Equals("guitar"))
        {
            EGuitar.SetActive(true);
        }
        else if (collision.gameObject.name.Equals("journal"))
        {
            EJournal.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        
        EController.SetActive(false);
        EGuitar.SetActive(false);
        EJournal.SetActive(false);
        
    }
    public void ControllerGrab()
    {

    }
}
