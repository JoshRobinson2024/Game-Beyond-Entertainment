using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public GameObject player;

    public Rigidbody2D controllerRB;
    public Rigidbody2D guitarRB;
    public Rigidbody2D journalRB;

    public Collider2D Controllercol;
    public Collider2D Guitarcol;
    public Collider2D Journalcol;
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
        if (EController.activeInHierarchy&& Input.GetKeyDown(KeyCode.E)&& grabbedObject!= true)
        {
            ControllerGrab();
            
        }
        else if(EGuitar.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            GuitarGrab();
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
        EController.SetActive(false);
        grabbedObject = true;
        controllerRB.isKinematic = true;

        Controller.transform.parent = player.transform;
        var newPos = new Vector2(player.transform.position.x, player.transform.position.y +2);

        Controller.transform.position = Vector3.MoveTowards(transform.position, newPos, 1000 * Time.deltaTime);
    }
    public void GuitarGrab()
    {
        EGuitar.SetActive(false);
        grabbedObject = true;
        guitarRB.isKinematic = true;

        Guitar.transform.parent = player.transform;
        var newPos = new Vector2(player.transform.position.x, player.transform.position.y + 2);

        Guitar.transform.position = Vector3.MoveTowards(transform.position, newPos, 1000 * Time.deltaTime);
    }
}
