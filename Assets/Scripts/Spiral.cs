using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    private float angle = 0f;

    private Vector2 bulletMoveDirections;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }
    private void Fire()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
