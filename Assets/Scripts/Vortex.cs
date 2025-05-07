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
    private float increment;
    public int whichAttack;
    public float startAngle;
    public float endAngle;
    public AudioSource VortexSource;
    
    public AudioClip VortexClipExplode;
    public AudioSource VortexSourceExplode;
    public void spawnVortex()
    {
        fadeOut = false;
        tpSelected = Random.Range(0, tpPoints.Length);
        wait = Random.Range(18.5f, 21.5f);
        currentVortex = Instantiate(vortex, tpPoints[tpSelected].transform.position, Quaternion.identity);
        Invoke("beginSuction", 1.5f);
        Invoke("stopSpraying", wait - 5);
        Invoke("endSuction", wait);
        whichAttack = Random.Range(0, 4);
        
    }
    private void Update()
    {
        if (BossHealth.victory)
        {
            endSuction();
            CancelInvoke("FireSpray");
            CancelInvoke("FireSpiral");
            CancelInvoke("FireMultiRing");
            CancelInvoke("FireRandomRing");
        }
    }
    public void beginSuction()
    {
        suction = true;
        VortexSource.Play();
        if (whichAttack == 0)
        {
            
            InvokeRepeating("FireSpray", 0, 0.03f);
        }
        else if (whichAttack == 1)
        {

            InvokeRepeating("FireSpiral", 0, 0.06f);
            
        }
        else if (whichAttack == 2)
        {
            InvokeRepeating("FireMultiRing", 0, 0.3f);
        }
        else if(whichAttack == 3)
        {
            InvokeRepeating("FireRandomRing", 0, 0.8f);
        }
        if (whichAttack == 4)
        {
            InvokeRepeating("FireSpray", 0, 0.03f);
        }
    }
    public void endSuction()
    {
        VortexSourceExplode.PlayOneShot(VortexClipExplode);
        VortexSource.Stop();
        fadeOut = true;
        suction = false;
        if(!BossHealth.victory)
        {
            FireBul();
            Invoke("FireBul", 0.07f);
            Invoke("FireBul", 0.14f);
        }
        
    }
    public void stopSpraying()
    {
        CancelInvoke("FireSpray");
        CancelInvoke("FireSpiral");
        CancelInvoke("FireMultiRing");
        CancelInvoke("FireRandomRing");

    }
    public void FireRandomRing()
    {
        if (Spawner.furyMode)
        {
            
            bulletsAmount = Random.Range(100, 120);
            angle = Random.Range(0, 361);
        }
        else
        {
            
            bulletsAmount = Random.Range(75, 85);
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
            bul.transform.Translate(bulDir * 75);
            bul.transform.rotation = currentVortex.transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(-bulDir);
            angle = Random.Range(0, 361);
        }

        
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
    private void FireMultiRing()
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
            bul.transform.position = currentVortex.transform.position;
            bul.transform.Translate(bulDir * 75);
            bul.transform.rotation = currentVortex.transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(-bulDir);
            angle += angleStep;

        }

        
    }
    private void FireSpiral()
    {
        increment = Random.Range(15, 25);
        angle += increment;
        if (angle >= 360)
        {
            angle = 0f;
        }
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Sin((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.transform.position = currentVortex.transform.position;
            bul.transform.position = currentVortex.transform.position + new Vector3(-2, 0, 0);
            bul.transform.Translate(bulDir * 75);
            bul.transform.rotation = currentVortex.transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(-bulDir);
            FireSpiral2();
        }
    }
    private void FireSpiral2()
    {
        increment = Random.Range(15, 25);
        angle += increment;
        if (angle >= 360)
        {
            angle = 0f;
        }
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Sin((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.transform.position = currentVortex.transform.position +new Vector3(2, 0, 0);
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
