using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 7f;

    public Rigidbody2D rb;
    PlayerMovement target;
    Vector2 moveDirection;
    Vector2 Distance;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMovement>();
        moveDirection = (target.transform.position - transform.position);
        Distance = (target.transform.position - transform.position);
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("Damage");
        }
    }
    private void Update()
    {
        //Debug.Log(moveSpeed);
        //Debug.Log(target);
        //Debug.Log(moveDirection);
        //Debug.Log(rb.velocity);
    }
}

