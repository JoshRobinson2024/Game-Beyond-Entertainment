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

    public ObjectDamage damage;
    public GuitarDamage gDamage;
    public JournalDamage jDamage;

    public string whatObject = "nothin'";

    public Vector2 direction;

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
        if (EController.activeInHierarchy&& Input.GetKeyDown(KeyCode.E)&& grabbedObject!= true && ObjectDamage.Grabbable == true)
        {
            EController.SetActive(false);
            grabbedObject = true;
            whatObject = "Controller";
            
            controllerRB.velocity = new Vector2(0, 0);
            controllerRB.bodyType = RigidbodyType2D.Dynamic;
            controllerRB.freezeRotation = true;
            InvokeRepeating("ControllerFollow", 0, Time.deltaTime);
        }
        else if(EGuitar.activeInHierarchy && Input.GetKeyDown(KeyCode.E) && grabbedObject != true && GuitarDamage.GuitarGrabbable == true)
        {
            EGuitar.SetActive(false);
            grabbedObject = true;
            whatObject = "Guitar";
            guitarRB.velocity = new Vector2(0, 0);
            guitarRB.bodyType = RigidbodyType2D.Dynamic;
            guitarRB.freezeRotation = true;
            InvokeRepeating("GuitarFollow", 0, Time.deltaTime);
        }
        else if(EJournal.activeInHierarchy&& Input.GetKeyDown(KeyCode.E) && grabbedObject != true && JournalDamage.JournalGrabbable == true)
        {
            EJournal.SetActive(false);
            grabbedObject = true;
            whatObject = "Journal";
            journalRB.velocity = new Vector2(0, 0);
            journalRB.bodyType = RigidbodyType2D.Dynamic;
            journalRB.freezeRotation = true;
            InvokeRepeating("JournalFollow", 0, Time.deltaTime);
        }
        /*else if(grabbedObject == true && whatObject == "Controller" && Input.GetKeyDown(KeyCode.E))
        {
            EController.SetActive(true);
            grabbedObject = false;
            controllerRB.isKinematic= true;
            controllerRB.freezeRotation = false;
            CancelInvoke("ControllerFollow");
        }*/
        /*else if (grabbedObject == true && whatObject == "Guitar" && Input.GetKeyDown(KeyCode.E))
        {
            EGuitar.SetActive(true);
            grabbedObject = false;
            guitarRB.isKinematic = true;
            guitarRB.freezeRotation = false;
            CancelInvoke("GuitarFollow");
        }*/
        /*else if (grabbedObject == true && whatObject == "Journal" && Input.GetKeyDown(KeyCode.E))
        {
            EJournal.SetActive(true);
            grabbedObject = false;
            journalRB.isKinematic = true;
            journalRB.freezeRotation = false;
            CancelInvoke("JournalFollow");
        }*/
        else if (grabbedObject == true && whatObject == "Controller" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

            Controller.transform.up = direction;
            EController.SetActive(true);
            grabbedObject = false;
            
            controllerRB.freezeRotation = false;
            CancelInvoke("ControllerFollow");
            ControllerThrow();
        }
        else if (grabbedObject == true && whatObject == "Guitar" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

            Guitar.transform.up = direction;
            EGuitar.SetActive(true);
            grabbedObject = false;

            guitarRB.freezeRotation = false;
            CancelInvoke("GuitarFollow");
            GuitarThrow();
        }
        else if (grabbedObject == true && whatObject == "Journal" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

            Journal.transform.up = direction;
            EJournal.SetActive(true);
            grabbedObject = false;

            journalRB.freezeRotation = false;
            CancelInvoke("JournalFollow");
            JournalThrow();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("controller") && grabbedObject != true && ObjectDamage.Grabbable == true)
        {
            EController.SetActive(true);

        }
        else if (collision.gameObject.name.Equals("guitar") && grabbedObject != true && GuitarDamage.GuitarGrabbable == true)
        {
            EGuitar.SetActive(true);
        }
        else if (collision.gameObject.name.Equals("journal") && grabbedObject != true && GuitarDamage.GuitarGrabbable == true)
        {
            EJournal.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("controller"))
        {
            EController.SetActive(false);

        }
        else if (collision.gameObject.name.Equals("guitar"))
        {
            EGuitar.SetActive(false);
        }
        else if (collision.gameObject.name.Equals("journal"))
        {
            EJournal.SetActive(false);
        }


    }
    
    
        



        
    
    public void ControllerFollow()
    {
        var newPos = new Vector2(player.transform.position.x, player.transform.position.y + 2);
        Controller.transform.position = Vector3.MoveTowards(transform.position, newPos, 10000 * Time.deltaTime);
    }
    public void GuitarFollow()
    {
        var newPos = new Vector2(player.transform.position.x, player.transform.position.y + 2);
        Guitar.transform.position = Vector3.MoveTowards(transform.position, newPos, 10000 * Time.deltaTime);
    }
    public void JournalFollow()
    {
        var newPos = new Vector2(player.transform.position.x, player.transform.position.y + 2);
        Journal.transform.position = Vector3.MoveTowards(transform.position, newPos, 10000 * Time.deltaTime);
    }
    public void ControllerThrow()
    {
        whatObject = "nothing";
        controllerRB.AddForce(direction * 100);
        Controllercol.GetComponent<CapsuleCollider2D>().enabled = true;
        damage.ControllerDamage();
    }
    public void GuitarThrow()
    {
        whatObject = "nothing";
        guitarRB.AddForce(direction * 100);
        Guitarcol.GetComponent<PolygonCollider2D>().enabled = true;
        gDamage.GDamage();
    }
    public void JournalThrow()
    {
        whatObject = "nothing";
        journalRB.AddForce(direction * 100);
        Journalcol.GetComponent<CapsuleCollider2D>().enabled = true;
        jDamage.JDamage();
    }
}
