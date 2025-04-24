using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    private Vector2 moveDirection;
    public float bulletLife = 5f;
    
    public TrailRenderer trailRenderer;

    /*
    void Awake()
    {
        Debug.Log("Awake");
        Invoke("Destroy", 5f);
    }
    */
    private void OnEnable()
    {
        //Debug.Log("Awake");
        Invoke("Destroy", 5f);
        Invoke("Trail", 0.25f);
    }
    private void Trail()
    {
        trailRenderer.emitting = true;
    }
    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    void Destroy()
    {
        
        gameObject.SetActive(false);
        trailRenderer.emitting = false;
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}

