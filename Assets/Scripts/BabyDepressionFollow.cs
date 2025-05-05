using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDepressionFollow : MonoBehaviour
{
    private Transform target;
    public float speed;
    private int bulletsAmount;
    public float startAngle;
    public float endAngle;
    public AudioSource ShootSource;
    public AudioClip ShootNoise;
    public AudioClip summon;
    public AudioSource summonSource;
    // Start is called before the first frame update
    void OnEnable()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("Fire", 2, 3);
        summonSource.PlayOneShot(summon);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerMovement.damaged)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
    }
    public void Fire()
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

        ShootSource.PlayOneShot(ShootNoise);
    }
}
