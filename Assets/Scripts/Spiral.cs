using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiral : MonoBehaviour
{
    private float angle = 0f;
    

    private Vector2 bulletMoveDirections;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireSpiral", 0f, 0.12f);
    }
    private void FireSpiral()
    {
        
        angle += 5f;
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
        
    }
    
}
