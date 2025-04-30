using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Canvas promptA;
    public Canvas promptB;
    public Canvas promptC;
    public Canvas promptD;
    // Start is called before the first frame update
    void Start()
    {
        promptA.enabled = false;
        promptB.enabled = false;
        promptC.enabled = false;
        promptD.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowA()
    {
        promptA .enabled = true;
    }
    public void ShowB() 
    {
        promptB .enabled = true;
    }
    public void ShowC() 
    { 
        promptC .enabled = true;
    }
    public void ShowD()
    {
        promptD .enabled = true;
    }
    public void RemoveA()
    {
        promptA.enabled = false;
    }
    public void RemoveB()
    {
        promptB.enabled = false;
    }
    public void RemoveC()
    {
        promptC.enabled = false;
    }
    public void RemoveD()
    {
        promptD.enabled = false;
    }
}
