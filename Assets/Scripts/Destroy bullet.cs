using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroybullet : MonoBehaviour
{
    public bool active = true;
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        /*
        //if(collision.gameObject.CompareTag("Bullet"))
        //{
            Debug.Log("Bomboclat");
            Destroy();

       // }*/
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
        
    }
}
