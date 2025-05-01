using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Teleport : MonoBehaviour
{
    public GameObject boss;
    public List<GameObject> TeleportList;
    private int placeToTeleport;
    private float time;
    public int fakeout;
    public Spawner spawner;
    public FakeoutRing ring;
    public Laser laser;
    public PlayerMovement mov;
    public Collider2D col;
    public Animator anim;
    public bool FirstBoss;
    
    public AudioClip teleport;
    public AudioSource teleportSource;
    public AudioSource teleportEnter;
    public AudioSource teleportExit;
    public AudioClip TeleportEnters;
    public AudioClip TeleportExits;

    public int whichAttack;

    // Start is called before the first frame update
    void Start()
    {
        
                
        anim = GetComponent<Animator>();
        if (FirstBoss)
        {
            anim.SetBool("TeleportExit", true);
        }
        else
        {
            anim.SetBool("TeleportExit", false);
        }
        anim.SetBool("TeleportFakeout", false);
        anim.SetBool("TeleportEnter", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void randomise()
    {
        
        teleportExit.PlayOneShot(TeleportExits);
        fakeout = Random.Range(0, 5);
    }
    public void randomiseLocation()
    {
        placeToTeleport = Random.Range(0, TeleportList.Count);
        if (TeleportList[placeToTeleport] == TeleportList[0] && mov.centreDisabled)
        {
            randomiseLocation();
        }
        else if (TeleportList[placeToTeleport] == TeleportList[1] && mov.tp1Disabled)
        {
            randomiseLocation();
        }
        else if (TeleportList[placeToTeleport] == TeleportList[2] && mov.tp2Disabled)
        {
            randomiseLocation();
        }
        else if (TeleportList[placeToTeleport] == TeleportList[3] && mov.tp3Disabled)
        {
            randomiseLocation();
        }
        else if (TeleportList[placeToTeleport] == TeleportList[4] && mov.tp4Disabled)
        {
            randomiseLocation();
        }
        else if (TeleportList[placeToTeleport] == TeleportList[5] && mov.tp5Disabled)
        {
            randomiseLocation();
        }
        else if (TeleportList[placeToTeleport] == TeleportList[6] && mov.tp6Disabled)
        {
            randomiseLocation();
        }
        else if (TeleportList[placeToTeleport] == TeleportList[7] && mov.tp7Disabled)
        {
            randomiseLocation();
        }
        else if (TeleportList[placeToTeleport] == TeleportList[8] && mov.tp8Disabled)
        {
            randomiseLocation();
        }
        else
        {
            Disappear();
        }
    }
    public void Disappear()
    {
        
        col.enabled = false;
        anim.SetBool("TeleportExit", true);
        anim.SetBool("TeleportFakeout", false);
        time = Random.Range(0.7f, 1.2f);
        Invoke("appear", time);
    }
    public void appear()
    {
        boss.transform.position = TeleportList[placeToTeleport].transform.position;
        col.enabled = true;
        if(fakeout > 0 )
        {
            teleportSource.PlayOneShot(teleport);
            anim.SetBool("TeleportFakeout", true);
            Debug.Log(fakeout);
            ring.randomise();
            ring.delayfire();
            ring.delayteleport();
            
            fakeout = fakeout - 1;
        }
        
        else
        {
            teleportEnter.PlayOneShot(TeleportEnters);
            ring.randomise();
            ring.delayfire();
            ring.delaystop();
            //Debug . Log(fakeout);
            anim.SetBool("TeleportExit", false);
            anim.SetBool("TeleportEnter", true);
            spawner.wait();
            Invoke("Reset", 1);
        }
    }
    public void Reset()
    {
        anim.SetBool("TeleportEnter", false);
    }
}
