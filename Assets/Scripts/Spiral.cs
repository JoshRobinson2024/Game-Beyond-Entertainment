using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    private float angle = 0f;
    private float wait;
    private float increment;
    private float timeToShoot;
    private Vector2 bulletMoveDirections;
    public Spawner spawner;
    // Start is called before the first frame update
    
    private void FireSpiral()
    {
        
        angle += increment;
        if (angle >= 360)
        {
            angle = 0f;
        }
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

        InvokeRepeating("FireSpiral", 0f, timeToShoot);
        Invoke("cease", wait);
    }
    public void randomise()
    {
        wait = Random.Range(6, 8);
        increment = Random.Range(7, 20);
        timeToShoot = Random.Range(0.04f, 0.1f);
    }
    private void cease()
    {
        CancelInvoke("FireSpiral");
        spawner.wait();
    }
    
}
