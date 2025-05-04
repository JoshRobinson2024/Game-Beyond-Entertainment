using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explode : MonoBehaviour
{
    private int bulletsAmount;
    private float startAngle;
    private float endAngle;
    public Collider2D hitbox;
    public GameObject explosion;

    private void OnEnable()
    {
        Invoke("HitboxEnable", 0.5f);
    }
    public void HitboxEnable()
    {
        fire();
        hitbox.enabled = true;
        Invoke("HitboxDisable", 0.1f);
    }
    public void HitboxDisable()
    {
        hitbox.enabled = false;
        Invoke("End", 0.4f);
    }
    public void End()
    {
        Destroy(explosion);
    }
    public void fire()
    {
        bulletsAmount = Random.Range(15, 25);
    
        startAngle = Random.Range(0, 360);
        endAngle = startAngle + 360;
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;
        for (int i = 0; i<bulletsAmount+1; i++)
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
    

    
}
