using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EFollower : MonoBehaviour
{
    
    public GameObject weapon;
    public float distance;
    public float grabbedDistance;
    public ObjectGrab ObjectGrab;
    public GameObject cHealthbar;
    public GameObject gHealthbar;
    public GameObject jHealthbar;
    public GameObject actualObject;


    // Update is called once per frame
    void Update()
    {
        if (ObjectGrab.whatObject == "Controller" && actualObject.name == "controller")
        {
            var newPos = new Vector2(weapon.transform.position.x, weapon.transform.position.y + grabbedDistance);

            cHealthbar.transform.position = Vector3.MoveTowards(transform.position, newPos, 1000 * Time.deltaTime);
        }
        else if(ObjectGrab.whatObject == "Guitar" && actualObject.name == "guitar")
        {
            var newPos = new Vector2(weapon.transform.position.x, weapon.transform.position.y + grabbedDistance);

            gHealthbar.transform.position = Vector3.MoveTowards(transform.position, newPos, 1000 * Time.deltaTime);
        }
        else if (ObjectGrab.whatObject == "Journal" && actualObject.name == "journal")
        {
            var newPos = new Vector2(weapon.transform.position.x, weapon.transform.position.y + grabbedDistance);

            jHealthbar.transform.position = Vector3.MoveTowards(transform.position, newPos, 1000 * Time.deltaTime);
        }
        else
        {
            var newPos = new Vector2(weapon.transform.position.x, weapon.transform.position.y + distance);

            transform.position = Vector3.MoveTowards(transform.position, newPos, 1000 * Time.deltaTime);
        }

        
    }
    
}
