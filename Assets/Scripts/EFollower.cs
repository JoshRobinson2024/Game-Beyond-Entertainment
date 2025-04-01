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


    // Update is called once per frame
    void Update()
    {
        if (ObjectGrab.grabbedObject == true)
        {
            var newPos = new Vector2(weapon.transform.position.x, weapon.transform.position.y + grabbedDistance);

            transform.position = Vector3.MoveTowards(transform.position, newPos, 1000 * Time.deltaTime);
        }
        else
        {
            var newPos = new Vector2(weapon.transform.position.x, weapon.transform.position.y + distance);

            transform.position = Vector3.MoveTowards(transform.position, newPos, 1000 * Time.deltaTime);
        }

        
    }
    
}
