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

    }
    public void LoadParents()
    {

    }
    public void LoadJournal()
    {

    }
}
