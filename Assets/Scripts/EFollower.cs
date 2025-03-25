using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EFollower : MonoBehaviour
{
    
    public GameObject weapon;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        var newPos = new Vector2(weapon.transform.position.x, weapon.transform.position.y+distance);
       
        transform.position = Vector3.MoveTowards(transform.position,newPos, 1000 * Time.deltaTime);

        
    }
    
}
