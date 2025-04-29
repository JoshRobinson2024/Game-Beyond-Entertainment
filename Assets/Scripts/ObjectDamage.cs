using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDamage : MonoBehaviour
{
    public bool Damaging = false;
    public BossHealth health;
    public static int Strength;
    public static float Controllerhealth;
    public Color damagingColour;
    public SpriteRenderer rend;
    public Color neutralColour;
    public Color brokenColour;
    public Image HealthBar;
    public static float currentControllerHealth;
    public static bool Grabbable = true;
    public GuitarDamage GDamage;
    public JournalDamage JDamage;
    public TrailRenderer trailRend;
    public GameObject Controller;
    private Vector2 ControllerRespawnPos;
    private bool broken;
    private void Start()
    {
        Controllerhealth = 5;
        currentControllerHealth = Controllerhealth;
        rend = GetComponent<SpriteRenderer>();
        Strength = 250;
        ControllerRespawnPos = Controller.transform.position;
        trailRend.emitting = false;
        rend.color = neutralColour;
        Grabbable = true;
        
    }
    public void heal()
    {
        if (currentControllerHealth < Controllerhealth)
        {
            currentControllerHealth += 1;
            HealthBar.fillAmount = currentControllerHealth / Controllerhealth;
            if (currentControllerHealth == Controllerhealth)
            {
                broken = true;
                rend.color = neutralColour;
                Grabbable = true;
            }
        }
    }
    public void ControllerDamage()
    {
        Damaging = true;
        rend.color = damagingColour;
        trailRend.emitting = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Damaging && collision.gameObject.CompareTag("Boss") && currentControllerHealth > 2)
        {
            
            Debug.Log("hit");
            LoseHealth(1);
            
            health.damage(Strength);
            GDamage.heal();
            JDamage.heal();
        }
        else if(Damaging && collision.gameObject.CompareTag("Boss") && currentControllerHealth == 2)
        {
            Debug.Log("hit");
            LoseHealth(1);
            
            health.damage(Strength/2);
            GDamage.heal();
            JDamage.heal();
        }
        else if (Damaging && collision.gameObject.CompareTag("Boss") && currentControllerHealth == 1)
        {
            Debug.Log("hit");
            LoseHealth(1);
            
            health.damage(Strength / 4);
            GDamage.heal();
            JDamage.heal();
        }
        else if (Damaging && collision.gameObject.CompareTag("Wall"))
        {
            
            Debug.Log("hit");
            LoseHealth(1);
            
            GDamage.heal();
            JDamage.heal();
        }
        if (collision.gameObject.CompareTag("OutOfBounds"))
        {

            Debug.Log("hit");
            LoseHealth(1);
            
            Controller.transform.position = ControllerRespawnPos;
            GDamage.heal();
            JDamage.heal();
        }
        if (currentControllerHealth == 0)
        {
            broken = true;
            Grabbable = false;
            rend.color = brokenColour;
            DialogueController.broken = true;
        }
        trailRend.emitting = false;
        Damaging = false;

        if (!broken)
        {
            
            rend.color = neutralColour;
        }
    }
    public void gainStrength(int strengthToGain)
    {
        Strength += strengthToGain;
    }
    public void LoseHealth(int damage)
    {
        currentControllerHealth -= damage;
        HealthBar.fillAmount = currentControllerHealth / Controllerhealth;
        
    }
}
