using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BossDeathController : MonoBehaviour
{
    public GameObject anim;
    public GameObject[] tpPoints;
    private int tpSelected;
    public GameObject explosionPrefab;
    public bool once = true;
    public GameObject Fade;
    public GameObject Fade2;
    public GameObject laser1;
    public GameObject laser2;
    public Fire Fire;
    public Spray Spray;
    public RandomRing RandomRing;
    public FakeoutRing FakeoutRing;
    public Teleport Teleport;
    public Laser Laser;
    public RotatingLaser RotatingLaser;
    public ExplosionLineAttack ExplosionLineAttack;
    public Vortex Vortex;
    public Spawner Spawner;
    public AudioClip BossDeathScream;
    public AudioSource BossDeathSource;
    public VictoryQuote VictoryQuote;
    public GameObject BulletPool;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BossAura()
    {
        anim.SetActive(true);
        Invoke("FadeOut", 2.5f);
    }
    public void FadeOut()
    {
        Fade.SetActive(true);
        Invoke("FadeOut2", 9.5f);
        VictoryQuote.Invoke("ShowText", 2);
        CancelInvoke("explode");
    }
    public void FadeOut2()
    {
        Fade2.SetActive(true);

    }
    public void explode()
    {
        tpSelected = Random.Range(0, tpPoints.Length);
        Instantiate(explosionPrefab, tpPoints[tpSelected].transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if (BossHealth.victory && once)
        {
            BossDeathSource.PlayOneShot(BossDeathScream);
            Fire.enabled = false;
            Spray.enabled = false;
            RandomRing.enabled = false;
            FakeoutRing.enabled = false;
            Teleport.enabled = false;
            Laser.enabled = false;
            RotatingLaser.enabled = false;
            ExplosionLineAttack.enabled = false;
            Vortex.enabled = false;
            Spawner.enabled = false;
            Destroy(laser1);
            Destroy(laser2);
            Destroy(BulletPool);
            once = false;
            Invoke("BossAura", 12f);
            InvokeRepeating("explode", 0, 0.3f);
        }
    }
}
