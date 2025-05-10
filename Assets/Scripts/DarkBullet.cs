using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class DarkBullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    private Vector2 moveDirection;
    public float bulletLife = 7f;
    public DarkColliderRemove col;
    public TrailRenderer trailRenderer;
    private Vector2 direction;
    public Rigidbody2D rb;
    public float x;
    public float y;
    /*
    void Awake()
    {
        Debug.Log("Awake");
        Invoke("Destroy", 5f);
    }
    */
    private void OnEnable()
    {


        randomise();
        
        
    }
    public void randomise()
    {
        x = UnityEngine.Random.Range(-10, 10);
        y = UnityEngine.Random.Range(-10, 10);
        
        
        
            direction = new Vector2(x, y).normalized;
            //Debug.Log("Awake");
            rb.AddForce(direction * 1500);
            Invoke("Remove", 7f);


            Invoke("Trail", 0.25f);
        
    }
    private void Trail()
    {
        trailRenderer.emitting = true;
    }
    public void Remove()
    {
        col.Remove();
        Invoke("Destroy", 10);
    }
    public void Destroy()
    {

        Destroy(gameObject);
        trailRenderer.emitting = false;
    }
    
    private void OnDisable()
    {
        CancelInvoke();
    }
}

