using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSpiral : MonoBehaviour
{
    private float angle = 0;

    private float increment = 0;

    

    


    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("anything it don't mattetr");
        redefine();
        InvokeRepeating("FireSpiral", 0f, 0.08f);
        InvokeRepeating("Redefine", 0f, 2f);
        
        
    }
    private void redefine()
    {
        angle = Random.Range(0, 360);
        increment = Random.Range(20, 27);
        
        CancelInvoke("FireSpiral");
        InvokeRepeating("FireSpiral", 0f, 0.08f);
    }
    private void FireSpiral()
    {

        angle += increment;
        if (angle >= 360)
        {
            angle = 0f;
        }
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Cos((angle  * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Sin((angle  * Mathf.PI) / 180f);

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
