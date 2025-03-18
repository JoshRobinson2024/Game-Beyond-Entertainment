using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool attkInProgress = false;
    private int attkSelected;
    public GameObject[] bullets;
    public Fire fire;
    public float waitTime;
    public Spiral spiral;
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
        fire.randomise();
        fire.delayfire();
        fire.delaystop();
        Invoke("Reset", 1);
    }
    private void Attk6()
    {
        attkInProgress = true;
        spiral.firing();
        Invoke("Reset", 1);
    }
    private void Attk5()
    {
        attkInProgress = true;
        Invoke("Reset", 1);
    }
    private void Attk4()
    {
        attkInProgress = true;
        Invoke("Reset", 1);
    }
    private void Attk3()
    {
        attkInProgress = true;
        Invoke("Reset", 1);
    }
    private void Attk2()
    {
        attkInProgress = true;
        Invoke("Reset", 1);
    }
    private void Attk1()
    {
        attkInProgress = true;
        Invoke("Reset", 1);
    }
    private void Reset()
    {
        attkInProgress = false;
    }
    private void wait()
    {
        waitTime = Random.Range(0.5f, 2);
        Invoke("Reset", waitTime);
    }
}

