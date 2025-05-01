using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialDialogueController : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public SceneManagement manager;
    public string[] lines;
    public float textSpeed;
    public List<GameObject> tpPoints;
    private int tpPointUsed;
    public AudioSource shadowVoice;
    public AudioClip darkVoice;
    public int index;
    public TMP_Text Text;
    public GameObject controller;
    public GameObject Guitar;
    public GameObject Journal;
    private float movePos;
    public string spawnController;
    public string spawnObjects;
    public string dash;
    public string Pickup;
    public string Move;
    public string Throw;
    public static bool thrown;
    public static bool moved;
    public static bool Pickedup;
    public static bool dashed;
    public static bool dashCheck;
    public static bool movedCheck;
    public static bool thrownCheck;
    public static bool PickedupCheck;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        textComponent.text = string.Empty;
        Invoke("NextLine", 2);
        PlayerMovement.maxHealth = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //if (lines[index] == dash)
        //{
        //    dash = "aaa";
        //    dashCheck = true;
        //}
        //else if (lines[index] == Pickup)
        //{
        //    Pickup = "aaa";
        //    PickedupCheck = true;
        //}
        //else if (lines[index] == Move)
        //{
        //    Move = "aaa";
        //    movedCheck = true;
        //}
        //else if (lines[index] == Throw)
        //{
        //    Throw = "aaa";
        //    thrownCheck = true;
        //}
        //if (dashCheck && dashed)
        //{
        //    index++;
        //    Invoke("NextLine", 1);
        //    dashed = false;
        //}
        //else if (movedCheck && moved)
        //{
        //    index++;
        //    Invoke("NextLine", 1);
        //    moved = false;
        //}
        //else if (PickedupCheck && Pickedup)
        //{
        //    index++;
        //    Invoke("NextLine", 1);
        //    Pickedup = false;
        //}
        //else if (thrownCheck && thrown)
        //{
        //    index++;
        //    Invoke("NextLine", 1);
        //    thrown = false;
        //}
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        tpPointUsed = Random.Range(0, tpPoints.Count);

        Text.transform.position = tpPoints[tpPointUsed].transform.position;
        Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;

        Invoke("NextLine", 4);
    }

    IEnumerator TypeLine()
    {
        shadowVoice.PlayOneShot(darkVoice);
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            //if (lines[index] == dash)
            //{
            //    dashCheck = true;
            //}
            //else if (lines[index] == Pickup)
            //{
            //    PickedupCheck = true;
            //}
            //else if (lines[index] == Move)
            //{
            //    movedCheck = true;
            //}
            //else if (lines[index] == Throw)
            //{
            //    thrownCheck = true;
            //}
            if (lines[index] == spawnController)
            {
                index++;
                textComponent.text = string.Empty;
                controller.SetActive(true);
                StartCoroutine(TypeLine());
                tpPointUsed = Random.Range(0, tpPoints.Count);
                Invoke("NextLine", 4);
            }
            else if (lines[index] == spawnObjects)
            {
                index++;
                textComponent.text = string.Empty;
                Guitar.SetActive(true);
                Journal.SetActive(true);
                StartCoroutine(TypeLine());
                tpPointUsed = Random.Range(0, tpPoints.Count);
                Invoke("NextLine", 4);
            }
            else
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
                tpPointUsed = Random.Range(0, tpPoints.Count);
                Invoke("NextLine", 4);
            }
        }
        else
        {
            manager.loadInteractionSelect();
        }









        Text.transform.position = tpPoints[tpPointUsed].transform.position;
        Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;


    }

}    



