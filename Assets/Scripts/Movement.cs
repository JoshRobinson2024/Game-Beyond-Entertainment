using System.Collections;
using System.Collections.Generic;

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
    public SceneManagement sceneManagement;

    public bool centreDisabled = false;
    public bool tp1Disabled = false;
    public bool tp2Disabled = false;
    public bool tp3Disabled = false;
    public bool tp4Disabled = false;
    public bool tp5Disabled = false;
    public bool tp6Disabled = false;
    public bool tp7Disabled = false;
    public bool tp8Disabled = false;

    Animator anim;

    private void Start()
    {
        
        maxHealth = 50;
        currentHealth = maxHealth;
        healthToLose = 10 - defense;
        activeMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("Dead", false);
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
        if (collision.gameObject.name.Equals("centreTeleportDenial"))
        {
            centreDisabled = true;
        }
        if (collision.gameObject.name.Equals("teleport1Denial"))
        {
            tp1Disabled = true;
        }
        if (collision.gameObject.name.Equals("teleport2Denial"))
        {
            tp2Disabled = true;
        }
        if (collision.gameObject.name.Equals("teleport3Denial"))
        {
            tp3Disabled = true;
        }
        if (collision.gameObject.name.Equals("teleport4Denial"))
        {
            tp4Disabled = true;
        }
        if (collision.gameObject.name.Equals("teleport5Denial"))
        {
            tp5Disabled = true;
        }
        if (collision.gameObject.name.Equals("teleport6Denial"))
        {
            tp6Disabled = true;
        }
        if (collision.gameObject.name.Equals("teleport7Denial"))
        {
            tp7Disabled = true;
        }
        if (collision.gameObject.name.Equals("teleport8Denial"))
        {
            tp8Disabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("centreTeleportDenial"))
        {
            centreDisabled = false;
        }
        if (collision.gameObject.name.Equals("teleport1Denial"))
        {
            tp1Disabled = false;
        }
        if (collision.gameObject.name.Equals("teleport2Denial"))
        {
            tp2Disabled = false;
        }
        if (collision.gameObject.name.Equals("teleport3Denial"))
        {
            tp3Disabled = false;
        }
        if (collision.gameObject.name.Equals("teleport4Denial"))
        {
            tp4Disabled = false;
        }
        if (collision.gameObject.name.Equals("teleport5Denial"))
        {
            tp5Disabled = false;
        }
        if (collision.gameObject.name.Equals("teleport6Denial"))
        {
            tp6Disabled = false;
        }
        if (collision.gameObject.name.Equals("teleport7Denial"))
        {
            tp7Disabled = false;
        }
        if (collision.gameObject.name.Equals("teleport8Denial"))
        {
            tp8Disabled = false;
        }
    }
    private void loseIFrames()
    {
        iFrames = false;
    }
    public void Death()
    {
        sceneManagement.LoadDeathScreen();
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("death...");
            Destroy (rb);

            cam.transform.parent = null;
            anim.SetBool("Dead", true);
            WillGaining.calculateDisplay();
            Invoke("Death", 1.5f);
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
        anim.SetFloat("MoveX", moveForce.x);
        anim.SetFloat("MoveY", moveForce.y);
        if(moveForce.x == 0 && moveForce.y == 0)
        {
            anim.SetBool("Moving", false);
        }
        else
        {
            anim.SetBool("Moving", true);
        }
    }

    
}

