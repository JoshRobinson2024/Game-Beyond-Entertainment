using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public SingleSpiral shooter;
    public SingleSpiral shooter2;
    public bool spiral1off = false;
    public bool spiral2off = false;
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
        if(spiral1off == true && spiral2off == true)
        {
            spiral1off = false;
            spiral2off = false;
            wait(); 
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
        shooter.Fire();
        shooter2.Fire();
        howlongtoshoot = Random.Range(4, 7);
        Invoke("endSpiral", howlongtoshoot);
        howlongtoshoot = Random.Range(4, 7);
        Invoke("endSpiral2", howlongtoshoot);
        


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
    public void endSpiral()
    {
        shooter.endfire();
        spiral1off = true;
        
    }
    public void endSpiral2()
    {
        shooter2.endfire();
        spiral2off = true;
    }
}

