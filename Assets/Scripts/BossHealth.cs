using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstGearGames.SmoothCameraShaker;
public class BossHealth : MonoBehaviour
{
    public ShakeData shakeData;
    public int health = 5000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void damage(int strength)
    {
        health -= strength;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            damage(100);
            CameraShakerHandler.Shake(shakeData);
        }
    }
}
