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
    public GameObject shooter1;
    public GameObject shooter2;
    public float howlongtoshoot = 0f;
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
        Debug.Log("Multiringattack");
        attkInProgress = true;
        fire.randomise();
        fire.delayfire();
        fire.delaystop();
        
    }
    private void Attk6()
    {
        Debug.Log("double spiral");
        attkInProgress = true;
        spiral.randomise();
        spiral.firing();
        
    }
    private void Attk5()
    {
        Debug.Log("cannonbalrog");
        attkInProgress = true;
        howlongtoshoot = Random.Range(4, 7);
        shooter1.SetActive(true);
        shooter2.SetActive(true);
        Invoke("Turnoffshooter", howlongtoshoot);
    }
    private void Attk4()
    {
        //...
    }
    private void Attk3()
    {
        //...
    }
    private void Attk2()
    {
        //...
    }
    private void Attk1()
    {
        //...
    }
    private void Reset()
    {
        attkInProgress = false;
    }
    public void wait()
    {
        Debug.Log("waiting");
        waitTime = Random.Range(0.5f, 2);
        Invoke("Reset", waitTime);
    }
    public void Turnoffshooter()
    {
        Debug.Log("Deactivating");
        shooter1.SetActive(false);
        shooter2.SetActive(false);
        wait();
    }
}

