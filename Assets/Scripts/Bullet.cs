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
        Debug.Log("sl;ifhjijaimwau");
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}

