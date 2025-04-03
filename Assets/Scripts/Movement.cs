using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    //I recommend 7 for the move speed, and 1.2 for the force damping
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 forceToApply;
    public Vector2 PlayerInput;
    public float forceDamping;
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    public static float maxHealth;
    public static float defense;
    public float currentHealth;
    public float healthToLose;
    public bool iFrames = false;
    public GameObject sprite;
    public Camera cam;
    public Image HealthBar;
    public WillGaining WillGaining;
    private void Start()
    {
        maxHealth = 1;
        currentHealth = maxHealth;
        healthToLose = 10 - defense;
        activeMoveSpeed = moveSpeed;
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Bullet"))
        {
            if (iFrames == false)
            {
                iFrames = true;
                currentHealth -= healthToLose;
                Debug.Log(currentHealth.ToString());
                Invoke("loseIFrames", 0.67f);
                HealthBar.fillAmount = currentHealth / maxHealth;
                
            }

        }
    }
    private void loseIFrames()
    {
        iFrames = false;
    }
    
    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("death...");
            Destroy (rb);
            cam.transform.parent = null;
            sprite.SetActive(false);
            WillGaining.calculateWill();
        }
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                Debug.Log("Dashhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                iFrames = true;
                Invoke("loseIFrames", 0.5f);
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
               
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;

        }

    }
    void FixedUpdate()
    {
        Vector2 moveForce = PlayerInput * activeMoveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        rb.velocity = moveForce;
    }

    
}

