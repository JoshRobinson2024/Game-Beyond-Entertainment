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
    
    public AudioClip ShootNoise;
    public AudioSource ShootSource;
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
            ShootSource.volume = 0.05f;

            ShootSource.PlayOneShot(ShootNoise);

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
        
        Invoke("cease", wait);
    }
    public void randomise()
    {
        
        timeToShoot = Random.Range(0.03f, 0.05f);
        if (Spawner.firstBattle || Spawner.furyMode)
        {
            timeToShoot = Random.Range(0.015f, 0.02f);
        }
    }
    private void cease()
    {
        ShootSource.volume = 0.5f;
        CancelInvoke("FireSpray");
        spawner.wait();
    }
    
    public void randomiseTime()
    {
        
        wait = Random.Range(10, 12);
        
    }
}
