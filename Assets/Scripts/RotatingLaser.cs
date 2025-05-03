using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class RotatingLaser : MonoBehaviour
{
    public GameObject rotator;
    
    public GameObject laser1;
    public Collider2D laser1col;
    public GameObject laser2;
    public Collider2D laser2col;
    public GameObject laser3;
    public Collider2D laser3col;
    //public GameObject laser4;
    //public Collider2D laser4col;
    //public GameObject laser5;
    //public Collider2D laser5col;
    //public GameObject laser6;
    //public Collider2D laser6col;
    //public GameObject laser7;
    //public Collider2D laser7col;
    //public GameObject laser8;
    //public Collider2D laser8col;

    private float timesFired;

    public AudioClip LaserSound;
    public AudioSource LaserSource;

    public Spawner spawner;

    public int reverse;

    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] float speedZ;
    void Update()
    {
        if (Spawner.firstBattle || Spawner.furyMode)
        {
            rotator.transform.Rotate(360 * speedX * Time.deltaTime, 360 * speedY * Time.deltaTime, 360 * speedZ * 2 *  Time.deltaTime);
        }
        else
        {
            rotator.transform.Rotate(360 * speedX * Time.deltaTime, 360 * speedY * Time.deltaTime, 360 * speedZ * Time.deltaTime);
        }
        
    }



    
    private void Start()
    {
        randomise();
        

        laser1.SetActive(false);
        laser2.SetActive(false);
        laser3.SetActive(false);
        //laser4.SetActive(false);
        //laser5.SetActive(false);
        //laser6.SetActive(false);
        //laser7.SetActive(false);
        //laser8.SetActive(false);



        laser1col.enabled = false;
        laser2col.enabled = false;
        laser3col.enabled = false;
        //laser4col.enabled = false;
        //laser5col.enabled = false;
        //laser6col.enabled = false;
        //laser7col.enabled = false;
        //laser8col.enabled = false;
    }

    public void randomise()
    {
        timesFired = Random.Range(2, 4);
        speedZ = Random.Range(0.02f, 0.06f);
        reverse = Random.Range(0, 2);
        if (reverse == 0)
        {
            speedZ = Random.Range(-0.02f, -0.06f);
        }
    }
    public void Rotationpart1()
    {
        speedZ = Random.Range(0.06f, 0.1f);
        reverse = Random.Range(0, 2);
        if (reverse == 0)
        {
            speedZ = Random.Range(-0.1f, -0.1f);
        }
        laser1.SetActive(false);
        laser2.SetActive(false);
        laser3.SetActive(false);
        //laser4.SetActive(false);
        //laser5.SetActive(false);
        //laser6.SetActive(false);
        //laser7.SetActive(false);
        //laser8.SetActive(false);

        //Debug.Log("Attack (Ihate unity's animator)");
        laser1.SetActive(true);
        laser2.SetActive(true);
        laser3.SetActive(true);
        //laser4.SetActive(true);
        //laser5.SetActive(true);
        //laser6.SetActive(true);
        //laser7.SetActive(true);
        //laser8.SetActive(true);
        Invoke("activateLaser", 0.4f);




    }
    public void activateLaser()
    {
        LaserSource.PlayOneShot(LaserSound);
        laser1col.enabled = true;
        laser2col.enabled = true;
        laser3col.enabled = true;
        //laser4col.enabled = true;
        //laser5col.enabled = true;
        //laser6col.enabled = true;
        //laser7col.enabled = true;
        //laser8col.enabled = true;
        Invoke("deactivateLaser", 0.7f);


    }


    public void deactivateLaser()
    {
        laser1col.enabled = false;
        laser2col.enabled = false;
        laser3col.enabled = false;
        //laser4col.enabled = false;
        //laser5col.enabled = false;
        //laser6col.enabled = false;
        //laser7col.enabled = false;
        //laser8col.enabled = false;
        
        if (timesFired == 0)
        {
            spawner.wait();
        }
        else
        {
            timesFired -= 1;

            Invoke("Rotationpart1", 0.3f);
        }

    }
}
