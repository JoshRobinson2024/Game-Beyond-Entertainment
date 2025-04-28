using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject rotator;
    public GameObject Player;
    public GameObject laser1;
    public Collider2D laser1col;
    public GameObject laser2;
    public Collider2D laser2col;
    public GameObject laser3;
    public Collider2D laser3col;
    public GameObject laser4;
    public Collider2D laser4col;
    public GameObject laser5;
    public Collider2D laser5col;
    public GameObject laser6;
    public Collider2D laser6col;
    public GameObject laser7;
    public Collider2D laser7col;
    public GameObject laser8;
    public Collider2D laser8col;

    public AudioClip LaserSound;
    public AudioSource LaserSource;

    public Teleport tp;
    
    public float timesFired;
    public bool teleporting;

    private float delay;

    private float rotation1;
    private float rotation2;
    private float rotation3;
    private float rotation4;
    private float rotation5;
    private float rotation6;
    private float rotation7;
    private float rotation8;

    public Spawner spawner;
    private void Start()
    {
        randomise();
        
        
        laser1.SetActive(false);
        laser2.SetActive(false);
        laser3.SetActive(false);
        laser4.SetActive(false);
        laser5.SetActive(false);
        laser6.SetActive(false);
        laser7.SetActive(false);
        laser8.SetActive(false);


        
        laser1col.enabled = false;
        laser2col.enabled = false;
        laser3col.enabled = false;
        laser4col.enabled = false;
        laser5col.enabled = false;
        laser6col.enabled = false;
        laser7col.enabled = false;
        laser8col.enabled = false;
    }
    
    public void randomise()
    {
        teleporting = false;
        timesFired = Random.Range(2, 4);
    }
    public void randomRotationpart1()
    {
        rotator.transform.Rotate(0, 0, Random.Range(0, 360));
        laser1.SetActive(false);
        laser2.SetActive(false);
        laser3.SetActive(false);
        laser4.SetActive(false);
        laser5.SetActive(false);
        laser6.SetActive(false);
        laser7.SetActive(false);
        laser8.SetActive(false);
        
        //Debug.Log("Attack (Ihate unity's animator)");
        laser1.SetActive(true);
        laser2.SetActive(true);
        laser3.SetActive(true);
        laser4.SetActive(true);
        laser5.SetActive(true);
        laser6.SetActive(true);
        laser7.SetActive(true);
        laser8.SetActive(true);
        Invoke("activateLaser", 0.4f);
        
        
        

    }
    public void activateLaser()
    {
        LaserSource.PlayOneShot(LaserSound);
        laser1col.enabled = true;
        laser2col.enabled = true;
        laser3col.enabled = true;
        laser4col.enabled = true;
        laser5col.enabled = true;
        laser6col.enabled = true;
        laser7col.enabled = true;
        laser8col.enabled = true;
        Invoke("deactivateLaser", 0.7f);

        
    }
    

    public void deactivateLaser()
    {
        laser1col.enabled = false;
        laser2col.enabled = false;
        laser3col.enabled = false;
        laser4col.enabled = false;
        laser5col.enabled = false;
        laser6col.enabled = false;
        laser7col.enabled = false;
        laser8col.enabled = false;

        if (timesFired == 0 && !teleporting)
        {

            spawner.wait();
        }
        else if (timesFired == 0 && teleporting)
        {
            tp.Invoke("randomiseLocation", 0.7f);
            teleporting = false;
        }
        else
        {
            timesFired -= 1;

            Invoke("randomRotationpart1", 0.3f);
        }
        
    }
    public void playertrack1()
    {
        delay = Random.Range(0.7f, 1f);
        rotation1 = Random.Range(0, 360);
        rotation2 = Random.Range(0, 360);
        rotation3 = Random.Range(0, 360);
        rotation4 = Random.Range(0, 360);
        rotation5 = Random.Range(0, 360);
        rotation6 = Random.Range(0, 360);
        rotation7 = Random.Range(0, 360);
        rotation8 = Random.Range(0, 360);
        laser1.transform.position = Player.transform.position;
        laser1.transform.Rotate(0, 0, rotation1);
        laser1.SetActive(true);
        Invoke("laserActivate1", 0.4f);
    }
    public void laserActivate1()
    {
        LaserSource.PlayOneShot(LaserSound);
        laser1col.enabled = true;
        Invoke("laserDeactivate1", 0.7f);
        Invoke("playerTrack2", delay);
    }
    public void laserDeactivate1()
    {
        laser1col.enabled = false;
        
        
    }
    public void playerTrack2()
    {
        
        laser2.transform.position = Player.transform.position;
        laser2.transform.Rotate(0, 0, rotation2);
        laser2.SetActive(true);
        Invoke("laserActivate2", 0.4f);
    }
    public void laserActivate2()
    {
        LaserSource.PlayOneShot(LaserSound);
        laser2col.enabled = true;
        Invoke("laserDeactivate2", 0.7f);
        Invoke("playerTrack3", delay);
    }
    public void laserDeactivate2()
    {
        laser2col.enabled = false;
        
        
    }
    public void playerTrack3()
    {
        
        laser3.transform.position = Player.transform.position;
        laser3.transform.Rotate(0, 0, rotation3);
        laser3.SetActive(true);
        Invoke("laserActivate3", 0.4f);
    }
    public void laserActivate3()
    {
        LaserSource.PlayOneShot(LaserSound);
        laser3col.enabled = true;
        Invoke("laserDeactivate3", 0.7f);
        Invoke("playerTrack4", delay);
    }
    public void laserDeactivate3()
    {
        laser3col.enabled = false;
        
        
    }
    public void playerTrack4()
    {
        
        laser4.transform.position = Player.transform.position;
        laser4.transform.Rotate(0, 0, rotation4);
        laser4.SetActive(true);
        Invoke("laserActivate4", 0.4f);
    }
    public void laserActivate4()
    {
        LaserSource.PlayOneShot(LaserSound);
        laser4col.enabled = true;
        Invoke("laserDeactivate4", 0.7f);
        Invoke("playerTrack5", delay);
    }
    public void laserDeactivate4()
    {
        laser4col.enabled = false;
        
        
    }
    public void playerTrack5()
    {
        
        laser5.transform.position = Player.transform.position;
        laser5.transform.Rotate(0, 0, rotation5);
        laser5.SetActive(true);
        Invoke("laserActivate5", 0.4f);
    }
    public void laserActivate5()
    {
        LaserSource.PlayOneShot(LaserSound);
        laser5col.enabled = true;
        Invoke("laserDeactivate5", 0.7f);
        Invoke("playerTrack6", delay);
    }
    public void laserDeactivate5()
    {
        laser5col.enabled = false;
        
        
    }
    public void playerTrack6()
    {
        
        laser6.transform.position = Player.transform.position;
        laser6.transform.Rotate(0, 0, rotation6);
        laser6.SetActive(true);
        Invoke("laserActivate6", 0.4f);
    }
    public void laserActivate6()
    {
        LaserSource.PlayOneShot(LaserSound);
        laser6col.enabled = true;
        Invoke("laserDeactivate6", 0.7f);
        Invoke("playerTrack7", delay);
    }
    public void laserDeactivate6()
    {
        laser6col.enabled = false;
        
        
    }
    public void playerTrack7()
    {
        
        laser7.transform.position = Player.transform.position;
        laser7.transform.Rotate(0, 0, rotation7);
        laser7.SetActive(true);
        Invoke("laserActivate7", 0.4f);
        
    }
    public void laserActivate7()
    {
        LaserSource.PlayOneShot(LaserSound);
        laser7col.enabled = true;
        Invoke("laserDeactivate7", 0.7f);
        Invoke("playerTrack8", delay);
    }
    public void laserDeactivate7()
    {
        laser7col.enabled = false;
        
        
    }
    public void playerTrack8()
    {
        
        laser8.transform.position = Player.transform.position;
        laser8.transform.Rotate(0, 0, rotation8);
        laser8.SetActive(true);
        Invoke("laserActivate8", 0.4f);
    }
    public void laserActivate8()
    {
        LaserSource.PlayOneShot(LaserSound);
        laser8col.enabled = true;
        Invoke("laserDeactivate8", 0.7f);
        
    }
    public void laserDeactivate8()
    {
        laser8col.enabled = false;
        
        Invoke("Reset", 0.5f);
    }
    public void Reset()
    {
        spawner.wait();
        laser1.transform.position = rotator.transform.position;
        laser1.transform.Rotate(0, 0, 360 - rotation1);
        laser2.transform.position = rotator.transform.position;
        laser2.transform.Rotate(0, 0, 360 - rotation2);
        laser3.transform.position = rotator.transform.position;
        laser3.transform.Rotate(0, 0, 360 - rotation3);
        laser4.transform.position = rotator.transform.position;
        laser4.transform.Rotate(0, 0, 360 - rotation4);
        laser5.transform.position = rotator.transform.position;
        laser5.transform.Rotate(0, 0, 360 - rotation5);
        laser6.transform.position = rotator.transform.position;
        laser6.transform.Rotate(0, 0, 360 - rotation6);
        laser7.transform.position = rotator.transform.position;
        laser7.transform.Rotate(0, 0, 360 - rotation7);
        laser8.transform.position = rotator.transform.position;
        laser8.transform.Rotate(0, 0, 360 - rotation8);
    }
}
