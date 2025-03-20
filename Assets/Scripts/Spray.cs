using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spray : MonoBehaviour
{
    private float angle = 0f;
    private float wait;
    private float timeToShoot;
    private Vector2 bulletMoveDirections;
    public Spawner spawner;
    public RandomRing ring;
    private float ringDelay1;
    private float ringDelay2;
    private float ringDelay3;
    private int fire1;
    private int fire2;
    private int fire3;
    private int fire4;
    // Start is called before the first frame update

    private void FireSpray()
    {

        angle = Random.Range(0, 361);
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);


        }
        for (int i = 0; i <= 125; i += 1)
        {
            if (i <= 250)
            {
                randomise();
            }
        }
    }
    public void firing()
    {

        InvokeRepeating("FireSpray", 0f, timeToShoot);
        /*if(fire1 == 0)
        {
            Invoke("RingFire1", ringDelay1);
        }*/
        if(fire2 == 0)
        {
            Invoke("RingFire2", ringDelay2);
        }
        if (fire3 == 0)
        {
            Invoke("RingFire3", ringDelay3);
        }
        if (fire4 == 0)
        {
            Invoke("RingFire4", timeToShoot);
        }
        Invoke("cease", wait);
    }
    public void randomise()
    {
        
        timeToShoot = Random.Range(0.03f, 0.06f);
    }
    private void cease()
    {
        CancelInvoke("FireSpray");
        spawner.wait();
    }
    public void RingFire1()
    {

        CancelInvoke("FireSpray");
        ring.Invoke("FireBul", 0.3f);
        timeToShoot = Random.Range(0.03f, 0.06f);
        InvokeRepeating("FireSpray", 0.6f, timeToShoot);
    }
    public void RingFire2()
    {
        CancelInvoke("FireSpray");
        ring.Invoke("FireBul", 0.3f);
        timeToShoot = Random.Range(0.03f, 0.06f);
        InvokeRepeating("FireSpray", 0.6f, timeToShoot);
    }
    public void RingFire3()
    {
        CancelInvoke("FireSpray");
        ring.Invoke("FireBul", 0.3f);
        timeToShoot = Random.Range(0.03f, 0.06f);
        InvokeRepeating("FireSpray", 0.6f, timeToShoot);
    }
    public void RingFire4()
    {
        CancelInvoke("FireSpray");
        ring.Invoke("FireBul", 0.3f);
        timeToShoot = Random.Range(0.03f, 0.06f);
        
    }
    public void randomiseTime()
    {
        ringDelay1 = Random.Range(2, 4);
        ringDelay2 = Random.Range(5, 7);
        ringDelay3 = Random.Range(8, 10);
        wait = Random.Range(10, 12);
        fire1 = Random.Range(0, 2);
        fire2 = Random.Range(0, 2);
        fire3 = Random.Range(0, 2);
        fire4 = Random.Range(0, 2);
    }
}
