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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void randomise()
    {
        fakeout = Random.Range(0, 5);
    }
    public void Disappear()
    {
        
        placeToTeleport = Random.Range(0, TeleportList.Count);
        boss.SetActive(false);
        time = Random.Range(0.5f, 1f);
        Invoke("appear", time);
    }
    public void appear()
    {
        boss.transform.position = TeleportList[placeToTeleport].transform.position;
        boss.SetActive(true);
        if(fakeout > 0)
        {
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
            Debug . Log(fakeout);
            spawner.wait();
        }
    }
    public void FindClosest()
    {
        
    }
}
