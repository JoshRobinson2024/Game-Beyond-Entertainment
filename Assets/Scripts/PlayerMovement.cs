using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public static bool damaged;
    public static bool iFrames = false;
    public GameObject sprite;
    public Camera cam;
    public Image HealthBar;
    public WillGaining WillGaining;
    public SceneManagement sceneManagement;
    public bool isDead;
    public Collider2D playerCol;
    public GameObject player;
    public GameObject blackHole;
    public float pullForce = 1f;
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
    
    public GameObject dashRefresh;
    private bool firstDash;
    public bool dash;
    public TrailRenderer trailRenderer;
    public bool firstLoss;
    public AudioClip BossMusic;
    public AudioSource BossSound;
    public AudioClip HitSound;
    public AudioSource HitPlayer;
    public AudioClip DeathSFX;
    public AudioSource DeathSFXPlayer;

    public bool locked;
    public SceneManagement SceneManagement;
    
    private void Start()
    {
        
        playerCol.enabled = true;
        HitPlayer.enabled = true;
        firstDash = false;
        trailRenderer.emitting = false;
        //
        //maxHealth = 100;
        //
        currentHealth = maxHealth;
        healthToLose = 10 - defense;
        activeMoveSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        
        anim = GetComponent<Animator>();
        anim.SetBool("Dead", false);
        isDead = false;
        dashRefresh.SetActive(false);
    }
    public void MusicStart()
    {
        BossSound.Play();
    }
    public void PlayDamageSound()
    {
        if (!isDead)
        {
            HitPlayer.PlayOneShot(HitSound);
            BossSound.volume = 0.7f;
            BossSound.pitch = 0.85f;
            BossSound.reverbZoneMix = 0.5f;
            Invoke("MusicRecover", 1f);
        }
    }
    public void MusicRecover()
    {
        BossSound.volume = 0.9f;
        BossSound.pitch = 1;
        BossSound.reverbZoneMix = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.name.Equals("Bullet") && !BossHealth.victory || collision.gameObject.name.Equals("BabyDepression(Clone)")&& !BossHealth.victory || collision.gameObject.CompareTag("Bullet") && !BossHealth.victory)
        {
            if (iFrames == false)
            {
                iFrames = true;
                damaged = true;
                currentHealth -= healthToLose;
                Debug.Log(currentHealth.ToString());
                Invoke("loseIFrames", 0.67f);
                HealthBar.fillAmount = currentHealth / maxHealth;
                Invoke("PlayDamageSound", 0.1f);
            }

        }
        else if (collision.gameObject.name.Equals("Kintsugi"))
        {
            sceneManagement.LoadTransform1();
        }
        else if (collision.gameObject.name.Equals("Credits trigger"))
        {
            SceneManagement.LoadThanks();
        }
        else if (collision.gameObject.name.Equals("Vortex(Clone)")&&!BossHealth.victory)
        {
            iFrames = true;
            currentHealth = 0;
            Debug.Log(currentHealth.ToString());
            Invoke("loseIFrames", 0.67f);
            HealthBar.fillAmount = currentHealth / maxHealth;
            Invoke("PlayDamageSound", 0.1f);
        }
        else if (collision.gameObject.name.Equals("laser") && !BossHealth.victory)
        {
            if (iFrames == false)
            {
                iFrames = true;
                currentHealth -= 12;
                Debug.Log(currentHealth.ToString());
                Invoke("loseIFrames", 0.67f);
                HealthBar.fillAmount = currentHealth / maxHealth;
                Invoke("PlayDamageSound", 0.1f);
            }
            
        }
        if (collision.gameObject.name.Equals("quiet"))
        {
            BossSound.volume = 0.5f;
        }
        if (collision.gameObject.name.Equals("medium"))
        {
            BossSound.volume = 0.75f;
        }
        if (collision.gameObject.name.Equals("loud"))
        {
            BossSound.volume = 1f;
        }

        if (collision.gameObject.name.Equals("BossEnterTrigger"))
        {
            sceneManagement.Invoke("LoadBoss", 3f);
            sceneManagement.BossStart();
            sceneManagement.FadeOut();

        }
        else if (collision.gameObject.name.Equals("FirstBossEnterTrigger"))
        {
            sceneManagement.FadeOut();
            sceneManagement.Invoke("LoadFirstBoss", 3f);
            sceneManagement.BossStart();
            
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
        damaged = false;
        iFrames = false;
    }
    public void Death()
    {

        InteractionSelectDialogueController.changeLine = true;
        if (firstLoss)
        {
            sceneManagement.LoadTutorial();
            InteractionCooldown.friendCoolDown = 1;
            InteractionCooldown.journalCoolDown = 2;
            InteractionCooldown.motherCoolDown = 3;
        }
        else
        {
            InteractionCooldown.reduceCooldown();
            sceneManagement.LoadDeathScreen();
            WillGaining.calculateDisplay();
        }
        
    }
    void Update()
    {
        
        if (currentHealth <= 0 && !BossHealth.victory)
        {
            CustomMouse.aiming = false;
            playerCol.enabled = false;
            Debug.Log("death...");
            HitPlayer.enabled = false;
            BossSound.Stop();
            isDead = true;
            WillGaining.CancelInvoke("CountTime");
            cam.transform.parent = null;
            anim.SetBool("Dead", true);
            DeathSFXPlayer.PlayOneShot(DeathSFX);
            sceneManagement.Invoke("FadeOut", 1f);
            Invoke("Death", 4f);
            currentHealth = 1;

        }
        if (!isDead && !locked)
        {
            PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if (TutorialDialogueController.movedCheck && ObjectGrab.grabbed)
            {
                TutorialDialogueController.moved = true;
                
            }
        }
        else if (dash)
        {
            PlayerInput = new Vector2(1, 0).normalized;
        }
        else
        {
            PlayerInput = new Vector2(0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !locked)
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                if (TutorialDialogueController.dashCheck)
                {
                    TutorialDialogueController.dashed = true;
                }
                Debug.Log("Dashhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                iFrames = true;
                Invoke("loseIFrames", dashLength);
                trailRenderer.emitting = true;
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                firstDash = true;
                dashRefresh.SetActive(false);
                activeMoveSpeed = moveSpeed;
                trailRenderer.emitting = false;
                dashCoolCounter = dashCooldown;
               
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;

        }
        if (dashCoolCounter <= 0 && firstDash)
        {
            dashRefresh.SetActive(true);
        }
        if (dash)
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {

                Debug.Log("Dashhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                iFrames = true;
                Invoke("loseIFrames", dashLength);
                trailRenderer.emitting = true;
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                firstDash = true;
                dashRefresh.SetActive(false);
                activeMoveSpeed = moveSpeed;
                trailRenderer.emitting = false;
                dashCoolCounter = dashCooldown;

            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;

        }
        if (dashCoolCounter <= 0 && firstDash)
        {
            dashRefresh.SetActive(true);
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
        if (Vortex.suction && !BossHealth.victory)
        {
            Vector2 direction = (Vector2)(Vortex.currentVortex.transform.position - player.transform.position);
            float distance = direction.magnitude;
            Vector2 pull = direction.normalized * 250f;
            rb.AddForce(pull);
        }
    }

    
}

