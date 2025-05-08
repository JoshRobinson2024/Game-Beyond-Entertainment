using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System;

public class SceneManagement : MonoBehaviour
{
    public AudioSource Transition;
    public AudioClip transitionClip;
    public Animator anim;
    public Animator fadeAnim;
    
    public bool transforming1;
    public bool transforming2;
    

    // Start is called before the first frame update
    void Start()
    {

        if (transforming1)
        {
            Invoke("FadeOut", 2);
            Invoke("goToNext", 4);
        }

        if (transforming2)
        {
            Invoke("FadeOut", 2);
            Invoke("goToNext2", 4);
        }


        fadeAnim.SetBool("FadeOut", false);
    }
    public void LoadTransform1()
    {
        FadeOut();
        Invoke("DelayedLoad1", 2);
    }
    public void DelayedLoad1()
    {
        SceneManager.LoadScene("Transform1");
    }
    public void goToNext()
    {
        SceneManager.LoadScene("Transform 2");
    }
    public void goToNext2()
    {
        SceneManager.LoadScene("FinalCorridor");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadCredits()
    {
        FadeOut();
        Invoke("DelayedLoadCredits", 1);
    }
    public void DelayedLoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadTitle()
    {
        FadeOut();
        Invoke("DelayedLoadTitle", 1);
    }
    public void DelayedLoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void LoadFirstCorridor()
    {
        FadeOut();
        Invoke("DelayedLoadFirstCorridor", 4);
        Transition.PlayOneShot(transitionClip);
    }
    public void DelayedLoadFirstCorridor()
    {
        SceneManager.LoadScene("FirstCorridor");
    }
    public void FadeOut()
    {
        fadeAnim.SetBool("FadeOut", true);
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
        InteractionSelectDialogueController.dayNumber++;
    }
    public void loadInteractionSelect()
    {
        FadeOut();
        Invoke("DelayedLoadInteractionSelect", 1);
    }
    public void DelayedLoadInteractionSelect()
    {
        SceneManager.LoadScene("InteractionSelect");
    }
    public void LoadCorridor()
    {
        Transition.PlayOneShot(transitionClip);
        FadeOut();
        Invoke("DelayedLoadCorridor", 4);
    }
    public void DelayedLoadCorridor()
    {
        
        SceneManager.LoadScene("Corridor");
    }
    public void LoadFriend()
    {
        FadeOut();
        Invoke("DelayedLoadFriend", 1);
    }
    public void DelayedLoadFriend()
    {
        SceneManager.LoadScene("Friend");
        InteractionSelectDialogueController.changeLine = false;
    }
    public void LoadParents()
    {
        FadeOut();
        Invoke("DelayedLoadParents", 1);
    }
    public void DelayedLoadParents()
    {
        SceneManager.LoadScene("Parent");
        InteractionSelectDialogueController.changeLine = false;
    }
    public void LoadJournal()
    {
        FadeOut();
        Invoke("DelayedLoadJournal", 1);
    }
    public void DelayedLoadJournal()
    {
        SceneManager.LoadScene("Journal");
        InteractionSelectDialogueController.changeLine = false;
    }
    public void LoadTutorial()
    {
        Spawner.firstBattle = false;
        PlayerMovement.maxHealth = 20;
        SceneManager.LoadScene("TheTutorial");
        InteractionSelectDialogueController.changeLine = true;
        InteractionSelectDialogueController.dayNumber = 1;
    }
    public void LoadFirstBoss()
    {
        Spawner.firstBattle = true;
        PlayerMovement.defense = 0;
        ObjectDamage.Controllerhealth = 2;
        ObjectDamage.Strength = 300;
        GuitarDamage.guitarStrength = 200;
        GuitarDamage.Guitarhealth = 3;
        JournalDamage.Journalhealth = 4;
        JournalDamage.journalStrength = 100;
        Costs.GamesCost = 1;
        Costs.GuitarCost = 1;
        Costs.JournalCost = 1;
        Costs.ControllerHealthCost = 1;
        Costs.GuitarHealthCost = 1;
        Costs.JournalHealthCost = 1;
        Costs.DoubleJournalHealthCost = 2;
        Costs.HealthAndDefenseCost = 5;
        SceneManager.LoadScene("FirstBoss");
    }
    public void LoadStat()
    {
        FadeOut();
        Invoke("DelayedLoadStat", 1);
    }
    public void DelayedLoadStat()
    {
        SceneManager.LoadScene("Stat");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
