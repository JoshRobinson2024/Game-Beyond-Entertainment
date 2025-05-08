using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Animator fademanager;
    private void Start()
    {
        Invoke("Fadeout", 4.5f);
    }
    public void Fadeout()
    {
        fademanager.SetBool("FadeOut", true);
        Invoke("nextScene", 1);
    }
    public void nextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
