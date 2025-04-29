using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool attkInProgress = false;
    private int attkSelected;
    public GameObject[] bullets;
    public Fire fire;
    public float waitTime;
    
    public SingleSpiral shooter;
    public SingleSpiral shooter2;
    public bool spiral1off = false;
    public bool spiral2off = false;
    public float howlongtoshoot = 0f;
    public int reuse = 0;
    public int usedAttack = 0;
    public Spray spray;
    public RandomRing ring;
    
    public float removalTime = 0f;
    public bool isDark = false;
    public Teleport teleport;
    public int attacksToteleport;
    public int attacksDone = 0;
    public Laser laser;
    public RotatingLaser rotLaser;
    private int laserAttkSelect;
    public BossAnimatorControl anim;

    // Start is called before the first frame update
    void Start()
    {
        attkInProgress = true;
        Invoke("tp", 0.1f);
        attacksToteleport = Random.Range(1, 4);
       

    }

    
    
    void Update()
    {

        
        if (attkInProgress == false)
        {
            if(attacksDone == attacksToteleport)
            {
                tp();
            }
            else
            {
                attkSelected = Random.Range(1, 8);
                laserAttkSelect = Random.Range(0, 2);
                //Debug.Log(attkSelected);
                if (attkSelected != usedAttack)
                {
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
        }
        if (spiral1off == true && spiral2off == true)
        {
            spiral1off = false;
            spiral2off = false;
            wait(); 
        }
    }
    private void Attk7()
    {
        attacksDone += 1;
        attkInProgress = true;
        usedAttack = 0;
        Debug.Log("Multiringattack");

        fire.times = Random.Range(1, 4);

        Invoke("Attk7Fire", 0.5f);

        anim.wave();
    }
    private void Attk7Fire()
    {
        fire.randomise();

        fire.delayfire();

        fire.delaystop();
    }
    private void Attk6()
    {
        attacksDone += 1;
        attkInProgress = true;
        usedAttack = 0;
        
        anim.ult();
        Invoke("Attk6Fire", 0.5f);
    }
    public void Attk6Fire()
    {
        laser.playertrack1();
    }
    private void Attk5()
    {
        attacksDone += 1;
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
        attacksDone += 1;
        attkInProgress = true;
        usedAttack = 0;
        Invoke("Attk4Fire", 0.5f);
        anim.ult();
    }
    private void Attk4Fire()
    {
        spray.randomise();
        spray.randomiseTime();
        spray.firing();
    }
    private void Attk3()
    {
        attacksDone += 1;
        attkInProgress = true;
        usedAttack = 0;
        ring.Invoke("DelayFire", 0.5f);
        anim.wave();
    }
    private void Attk2()
    {
        attacksDone +=1;
        attkInProgress = true;
        Invoke("Attk2Fire", 0.5f);
        anim.ult();
    }
    private void Attk2Fire()
    {
        rotLaser.randomise();
        rotLaser.Rotationpart1();
    }
    private void Attk1()
    {
        attacksDone += 1;
        attkInProgress = true;
        usedAttack = 0;
        anim.ult();
        Invoke("Attk1Fire", 0.5f);
    }
    private void Attk1Fire()
    {

        laser.randomise();
        laser.randomRotationpart1();






    }
    private void tp()
    {
        attkInProgress = true;
        laser.laser1.SetActive(false);
        laser.laser2.SetActive(false);
        laser.laser3.SetActive(false);
        laser.laser4.SetActive(false);
        laser.laser5.SetActive(false);
        laser.laser6.SetActive(false);
        laser.laser7.SetActive(false);
        laser.laser8.SetActive(false);
        rotLaser.laser1.SetActive(false);
        rotLaser.laser2.SetActive(false);
        rotLaser.laser3.SetActive(false);
        teleport.randomise();
        
        attacksDone = 0;
        attacksToteleport = Random.Range(1, 4);
        teleport.randomiseLocation();
        
    }
    private void Reset()
    {
        laser.laser1.SetActive(false);
        laser.laser2.SetActive(false);
        laser.laser3.SetActive(false);
        laser.laser4.SetActive(false);
        laser.laser5.SetActive(false);
        laser.laser6.SetActive(false);
        laser.laser7.SetActive(false);
        laser.laser8.SetActive(false);
        rotLaser.laser1.SetActive(false);
        rotLaser.laser2.SetActive(false);
        rotLaser.laser3.SetActive(false);
        reuse = Random.Range(0, 2);
        if (attkSelected == 1)
        {
            usedAttack = 1;
        }
        else if (reuse == 0)
        {
            usedAttack = attkSelected;
        }
        attkInProgress = false;
        //Debug.Log(attkInProgress);
    }
    public void wait()
    {
        //Debug.Log(attacksDone);
        waitTime = Random.Range(0.5f, 1.5f);
        anim.stopWaving();
        anim.stopUlt();
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
        
        isDark = false;
    }
    
}

