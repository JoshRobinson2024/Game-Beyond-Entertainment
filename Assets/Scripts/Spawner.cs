using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool attkInProgress = false;
    private int attkSelected;
    public GameObject[] bullets;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (attkInProgress == false)
        {
            attkSelected = Random.Range(1, 8);
            //Debug.Log(attkSelected);
            switch (attkSelected)
            {
                case 7:
                    Attk7();
                    break;
                case 6:
                    Attk6();
                    break;
                case 5:
                    Attk5();
                    break;
                case 4:
                    Attk4();
                    break;
                case 3:
                    Attk3();
                    break;
                case 2:
                    Attk2();
                    break;
                case 1:
                    Attk1();
                    break;
            }
        }
    }
    private void Attk7()
    {
        attkInProgress = true;
        Instantiate(bullets[1]);
        Invoke("Reset", 1);
    }
    private void Attk6()
    {
        //...
    }
    private void Attk5()
    {
        // ...
    }
    private void Attk4()
    {
        // ...
    }
    private void Attk3()
    {
        // ...
    }
    private void Attk2()
    {
        //...
    }
    private void Attk1()
    {
        // ...
    }
    private void Reset()
    {
        attkInProgress = false;
    }
}

