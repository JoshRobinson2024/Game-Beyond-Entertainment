using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public AudioSource Transition;
    public AudioClip transitionClip;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BossStart()
    {
        Transition.PlayOneShot(transitionClip);
        anim.SetBool("FightEnter", true);
    }
    public void LoadBoss()
    {

        SceneManager.LoadScene("Boss fight");
    }
    public void LoadDeathScreen()
    {
        SceneManager.LoadScene("WillGaining");
    }
    public void loadInteractionSelect()
    {
        SceneManager.LoadScene("InteractionSelect");
    }
    public void LoadCorridor()
    {
        SceneManager.LoadScene("Corridor");
    }
    public void LoadFriend()
    {
        SceneManager.LoadScene("Friend");
    }
    public void LoadParents()
    {
        SceneManager.LoadScene("Parent");
    }
    public void LoadJournal()
    {
        SceneManager.LoadScene("Journal");
    }
    public void LoadFirstBoss()
    {
        
        PlayerMovement.defense = 0;
        ObjectDamage.Controllerhealth = 2;
        ObjectDamage.Strength = 3;
        GuitarDamage.guitarStrength = 2;
        GuitarDamage.Guitarhealth = 3;
        JournalDamage.Journalhealth = 4;
        JournalDamage.journalStrength = 1;
        Costs.GamesCost = 1;
        Costs.GuitarCost = 1;
        Costs.JournalCost = 1;
        Costs.ControllerHealthCost = 1;
        Costs.GuitarHealthCost = 1;
        Costs.JournalHealthCost = 1;
        Costs.DoubleJournalHealthCost = 2;
        SceneManager.LoadScene("FirstBoss");
    }
}
