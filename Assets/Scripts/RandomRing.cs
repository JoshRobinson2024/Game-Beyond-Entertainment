using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRing : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;
    public Spawner spawner;
    private float delay = 0;
    private int timesshot = 0;
    private float angle = 0;
    public AudioClip ShootNoise;
    public AudioSource ShootSource;
    private void Update()
    {
        if (BossHealth.victory)
        {
            CancelInvoke("FireBul");
        }
    }
    public void FireBul()
    {
        if (Spawner.furyMode)
        {
            delay = Random.Range(0.5f, 0.7f);
            bulletsAmount = Random.Range(100, 120);
            angle = Random.Range(0, 361);
        }
        else
        {
            delay = Random.Range(0.7f, 1.4f);
            bulletsAmount = Random.Range(75, 85);
            angle = Random.Range(0, 361);
        }
        
        
        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirx = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDiry = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirx, bulDiry, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            angle = Random.Range(0, 361); 

        }

        ShootSource.PlayOneShot(ShootNoise);
    }
    public void DelayFire()
    {
        timesshot = Random.Range(4, 7);
        delay = Random.Range(0.5f, 1.2f);
        if (Spawner.furyMode)
        {
            timesshot = Random.Range(6, 8);
            delay = Random.Range(0.5f, 0.7f);
        }
        InvokeRepeating("FireBul", 0f, delay);
        Invoke("EndFiring", timesshot * delay);
    }
    public void EndFiring()
    {
        CancelInvoke("FireBul");
        spawner.wait();
    }
}
