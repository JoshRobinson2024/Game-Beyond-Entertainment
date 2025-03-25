using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeoutRing : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 0f, endAngle = 360f;


    private Vector2 bulletMoveDirection;
    private float delay = 0.6f;


    private float timesshot;
    public Teleport teleport;
    public void FireBul()
    {
        bulletsAmount = Random.Range(15, 20);
        startAngle = Random.Range(0, 360);
        endAngle = startAngle + 360;
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;
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
            angle += angleStep;

        }


    }
    public void delayfire()
    {

        InvokeRepeating("FireBul", 0f, delay);
    }
    public void stop()
    {
        CancelInvoke("FireBul");
        
    }
    
    public void teleporting()
    {
        CancelInvoke("FireBul");
        teleport.Invoke("Disappear", 0.7f);
    }
    public void delaystop()
    {
        Invoke("stop", delay * timesshot);
    }
    public void delayteleport()
    {
        Invoke("teleporting", delay * timesshot);
    }
    public void randomise()
    {

        timesshot = Random.Range(3, 5);
        delay = Random.Range(0.04f, 0.06f);
    }

}
