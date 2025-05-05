using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.EventSystems;

public class Vortex : MonoBehaviour
{
    
    public GameObject vortex;
    public static GameObject currentVortex;
    public GameObject[] tpPoints;
    private int tpSelected;
    private float angle;
    private float wait;
    private int bulletsAmount;
    public static bool suction;
    public static bool fadeOut;
    public void spawnVortex()
    {
        fadeOut = false;
        tpSelected = Random.Range(0, tpPoints.Length);
        wait = Random.Range(18.5f, 21.5f);
        currentVortex = Instantiate(vortex, tpPoints[tpSelected].transform.position, Quaternion.identity);
        Invoke("beginSuction", 1.5f);
        Invoke("stopSpraying", wait - 5);
        Invoke("endSuction", wait);
    }
    public void beginSuction()
    {
        suction = true;
        InvokeRepeating("FireSpray", 0, 0.03f);
    }
    public void endSuction()
    {
        fadeOut = true;
        suction = false;
        FireBul();
        Invoke("FireBul", 0.07f);
        Invoke("FireBul", 0.14f);
    }
    public void stopSpraying()
    {
        CancelInvoke("FireSpray");
        

    }
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
            bul.transform.position = currentVortex.transform.position;
            bul.transform.Translate(bulDir * 75);
            bul.transform.rotation = currentVortex.transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(-bulDir);
            
        }
    }
    public void FireBul()
    {
        if (Spawner.furyMode)
        {
            
            bulletsAmount = Random.Range(70, 80);
            angle = Random.Range(0, 361);
        }
        else
        {
            
            bulletsAmount = Random.Range(60, 70);
            angle = Random.Range(0, 361);
        }


        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirx = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDiry = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirx, bulDiry, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = currentVortex.transform.position;
            bul.transform.rotation = currentVortex.transform.rotation;
            
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            angle = Random.Range(0, 361);

        }

        
    }
}
