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

    private float timesshot;
    public Spawner spawner;
    public void FireBul()
    {
        bulletsAmount = Random.Range(15, 25);
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
            ;
        }
        
    }
    public void delayfire()
    {
        
        InvokeRepeating("FireBul", 0f, 0.6f);
    }
    public void stop()
    {
        CancelInvoke("FireBul");
        spawner.wait();
    }
    public void delaystop()
    {
        Invoke("stop", timesshot*0.6f);
    }
    public void randomise()
    {
        
        timesshot = Random.Range(2, 5);

    }
}
