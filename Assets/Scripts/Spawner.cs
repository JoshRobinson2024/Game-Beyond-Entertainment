using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public static bool phase2;
    public static bool phase3;
    public static bool furyMode;
    public static bool firstBattle;
    [SerializeField]
    private int bulletsAmount = 1;

    


    private Vector2 bulletMoveDirection;
    

    public int times = 1;



    public ExplosionLineAttack explosion;
    public AudioClip ShootNoise;
    public AudioSource ShootSource;
    public bool locked;
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
    
    public Vortex Vortex;
    public GameObject babyDepression;
    public GameObject[] tpPoints;
    private int tpSelected;
    
    // Start is called before the first frame update
    void Start()
    {
        attkInProgress = true;
        Invoke("lockCheck", 0.5f);

        InvokeRepeating("SpawnBabyDepression", 15, 30);
        phase2 = true;
        
        
        attacksToteleport = Random.Range(1, 4);
       

    }

    public void lockCheck()
    {
        if (!locked)
        {
            tp();
        }
    }
    public void SpawnBabyDepression()
    {
        tpSelected = Random.Range(0, tpPoints.Length);
        Instantiate(babyDepression, tpPoints[tpSelected].transform.position, Quaternion.identity);
    }
    void Update()
    {

        if (locked)
        {
            attkInProgress = false;
        }
        if (attkInProgress == false && !locked && !firstBattle)
        {
            if (attacksDone == attacksToteleport)
            {
                tp();
            }
            else
            {
                attkSelected = Random.Range(1, 12);
                
                laserAttkSelect = Random.Range(0, 2);
                //Debug.Log(attkSelected);
                if (attkSelected != usedAttack)
                {
                    switch (attkSelected)
                    {
                        case 11:
                            Attk11();
                            break;
                        case 10:
                            Attk10();
                            break;
                        case 9:
                            Attk9();
                            break;
                        case 8:
                            Attk8();
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
        }
        else if (firstBattle && !locked && !attkInProgress)
        {
            attkSelected = Random.Range(1, 6);
            switch (attkSelected)
            {
                case 5:
                    Attk5();
                    break;
                case 4:
                    Attk6();
                    break;
                case 3:
                    Attk4();
                    break;
                case 2:
                    Attk2();
                    break;
                case 1:
                    Attk1();
                    break;
            }
        }
        if (spiral1off == true && spiral2off == true)
        {
            spiral1off = false;
            spiral2off = false;
            wait(); 
        }
    }
    private void Attk11()
    {
        if (phase2||phase3||furyMode)
        {
            attacksDone += 1;
            attkInProgress = true;
            usedAttack = 0;
            anim.ult();
            Vortex.spawnVortex();
            Invoke("wait", 17);
        }
        
    }
    private void Attk10()
    {
        if (phase2 || phase3 || furyMode)
        {
            attacksDone += 1;
            attkInProgress = true;
            usedAttack = 0;
            anim.wave();
            explosion.lineAttack = false;
            explosion.RandomAttack = false;
            explosion.FollowAttack = true;
            explosion.ExecuteExplosionLineAttack();
            Invoke("wait", 6.5f);
        }
            
    }
    private void Attk9()
    {
        if (phase2 || phase3 || furyMode)
        {
            attacksDone += 1;
            attkInProgress = true;
            usedAttack = 0;
            anim.wave();
            explosion.lineAttack = false;
            explosion.RandomAttack = true;
            explosion.FollowAttack = false;
            explosion.ExecuteExplosionLineAttack();
            explosion.Invoke("ExecuteExplosionLineAttack", 3f);
            explosion.Invoke("ExecuteExplosionLineAttack", 6f);

            Invoke("wait", 8);
        }
        
    }
    private void Attk8()
    {
        if (phase2 || phase3 || furyMode)
        {
            attacksDone += 1;
            attkInProgress = true;
            usedAttack = 0;
            anim.wave();
            explosion.RandomAttack = false;
            explosion.lineAttack = true;
            explosion.FollowAttack = false;
            explosion.ExecuteExplosionLineAttack();
            explosion.Invoke("ExecuteExplosionLineAttack", 2.5f);
            explosion.Invoke("ExecuteExplosionLineAttack", 4.5f);

            Invoke("wait", 5);
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
        else if (attkSelected == 11)
        {
            usedAttack = 11;
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
        if (furyMode)
        {
            waitTime = 1.5f;
        }
        else if (firstBattle)
        {
            waitTime = 0.5f;
        }
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
    public void bulletDodge()
    {
        
        
        
        float angle = 180;
        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirx = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDiry = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirx, bulDiry, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = new Vector3(0, 10, 0);
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            

        }

        ShootSource.PlayOneShot(ShootNoise);
    }
}

