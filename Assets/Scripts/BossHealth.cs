using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    
    public int health = 5000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void damage(int strength)
    {
        health -= strength;
    }
    
}
