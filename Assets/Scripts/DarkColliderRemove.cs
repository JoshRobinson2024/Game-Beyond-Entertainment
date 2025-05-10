using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkColliderRemove : MonoBehaviour
{
    public Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Remove()
    {
        col.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
