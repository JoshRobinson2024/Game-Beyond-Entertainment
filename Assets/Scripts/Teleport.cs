using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject boss;
    public List<GameObject> TeleportList;
    private int placeToTeleport;
    private float time;
    public int fakeout;
    public Spawner spawner;
    public FakeoutRing ring;
    public PlayerMovement mov;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("TeleportEnter", false);
        anim.SetBool("TeleportFakeout", false);
        anim.SetBool("TeleportExit", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void randomise()
    {
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

        anim.SetBool("TeleportExit", true);
        anim.SetBool("TeleportFakeout", false);
        time = Random.Range(0.7f, 1.2f);
        Invoke("appear", time);
    }
    public void appear()
    {
        boss.transform.position = TeleportList[placeToTeleport].transform.position;
        
        if(fakeout > 0)
        {
            anim.SetBool("TeleportFakeout", true);
            Debug.Log(fakeout);
            ring.randomise();
            ring.delayfire();
            ring.delayteleport();
            
            fakeout = fakeout - 1;
        }
        else
        {
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
