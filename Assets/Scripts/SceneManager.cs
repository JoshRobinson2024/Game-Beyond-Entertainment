using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
