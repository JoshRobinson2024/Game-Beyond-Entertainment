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
    public int reuse = 0;
    public int usedAttack = 0;
    public Spray spray;
    public RandomRing ring;
    public GameObject darkness;
    public float removalTime = 0f;
    public bool isDark = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        darkness.SetActive(false);
    }

    
    void Update()
    {
        
        if (attkInProgress == false)
        {
            attkSelected = Random.Range(1, 10);
            //Debug.Log(attkSelected);
            if (attkSelected != usedAttack )
            {
                switch (attkSelected)
                {
                    case 9:
                        Attk1();
                        break;
                    case 8:
                        Attk1();
                        break;
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
        if(spiral1off == true && spiral2off == true)
        {
            spiral1off = false;
            spiral2off = false;
            wait(); 
        }
    }
    private void Attk7()
    {
        attkInProgress = true;
        usedAttack = 0;
        Debug.Log("Multiringattack");
        
        fire.randomise();
        
        fire.delayfire();

        fire.delaystop();
    }
    private void Attk6()
    {
        attkInProgress = true;
        usedAttack = 0;
        Debug.Log("double spiral");
        
        spiral.randomise();
        spiral.firing();
         
    }
    private void Attk5()
    {
        attkInProgress = true;
        usedAttack = 0;
        Debug.Log("cannonbalrog");
        
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
        attkInProgress= true;
        usedAttack = 0;
        spray.randomise();
        spray.randomiseTime();
        spray.firing();
    }
    private void Attk3()
    {
        attkInProgress = true;
        usedAttack = 0;
        ring.DelayFire();
        
    }
    private void Attk2()
    {
        if (isDark == false)
        {
            removalTime = Random.Range(20, 30);
            attkInProgress = true;
            isDark = true;
            darkness.SetActive(true);
            
            Invoke("removeDarknessAnim", removalTime - 5);
            Invoke("removeDarkness", removalTime);
            wait();
        }
        
    }
    private void Attk1()
    {
        
        
    }
    private void Reset()
    {
        reuse = Random.Range(0, 2);
        if (reuse == 0)
        {
            usedAttack = attkSelected;
        }
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
    public void removeDarkness()
    {
        darkness.SetActive(false);
        isDark = false;
    }
    
}

