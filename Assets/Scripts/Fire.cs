using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 0f, endAngle = 360f;

    
    private Vector2 bulletMoveDirection;
    private float delay = 0.6f;

    public int times;

    private float timesshot;
    public Spawner spawner;

    public AudioClip ShootNoise;
    public AudioSource ShootSource;
    public void FireBul()
    {
        if (Spawner.furyMode)
        {
            bulletsAmount = Random.Range(25, 35);
        }
        else
        {
            bulletsAmount = Random.Range(15, 25);
        }
        startAngle = Random.Range(0, 360);
        endAngle = startAngle + 360;
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;
        for (int i = 0; i < bulletsAmount+1; i++)
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
            angle += angleStep;
            
        }

        ShootSource.PlayOneShot(ShootNoise);
    }
    public void delayfire()
    {
        
        InvokeRepeating("FireBul", 0f, delay);
    }
    public void stop()
    {
        CancelInvoke("FireBul");
        if (times == 0)
        {
            spawner.wait();
        }
        else
        {
            times -= 1;
            Invoke("refire", Random.Range(0.5f, 1f));
        }
    }
    public void delaystop()
    {
        Invoke("stop", delay * timesshot);
    }
    public void randomise()
    {
        
        timesshot = Random.Range(3, 6);
        delay = Random.Range(0.15f, 0.35f);
        if (Spawner.furyMode)
        {
            timesshot = Random.Range(5, 8);
            delay = Random.Range(0.1f, 0.2f);
        }
    }
    public void refire()
    {
        randomise();

        delayfire();

        delaystop();
    }
}
