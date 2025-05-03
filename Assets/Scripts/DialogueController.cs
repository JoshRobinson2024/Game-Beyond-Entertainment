using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    
    public string[] lines;
    public float textSpeed;

    private int index;
    public TMP_Text Text;
    private float movePos;
    private Vector2 posX;

    public bool inCorridor;
    public bool inBoss;
    public bool phaseChange;
    public bool Death;
    public bool Final;
    public bool interaction;
    private int repeat;
    public static bool broken;
    private bool brokenOnce;
    public List<GameObject> tpPoints;
    private int tpPointUsed;
    public AudioSource shadowVoice;
    public AudioClip darkVoice;
    public AudioSource typingSource;
    public AudioClip typingSound;
    public GameObject arrow;
    public string checkA;
    public string checkB;
    public string checkC;
    public string checkD;
    public ButtonManager button;
    public bool halt;
    public bool Journal;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        if (inCorridor)
        {
            index = Random.Range(0, lines.Length);
            tpPointUsed = Random.Range(0, tpPoints.Count);
            
            Text.transform.position = tpPoints[tpPointUsed].transform.position;
            Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;
            Invoke ("startDialogue", 2);
        }
        
        else if (interaction)
        {
            arrow.SetActive (false);
            index = 0;
            Invoke("startDialogue", 0.1f);
        }

        
        
        textComponent.text = string.Empty;
        


    }

    // Update is called once per frame
    void Update()
    {
        if (textComponent.text == lines[index] && interaction)
        {
            arrow.SetActive(true);
            if (Journal)
            {
                typingSource.Pause();
            }
        }
        if (!halt)
        {
            if (Input.GetMouseButtonDown(0) && interaction)
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                    arrow.SetActive(false);
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
        if(broken && !brokenOnce)
        {
            brokenOnce = true;
            startDialogue();
        }
        
    }

    public void startDialogue()
    {
        if (broken)
        {
            index = Random.Range(15, 18);
            textComponent.text = string.Empty;
            Text.transform.position = tpPoints[tpPointUsed].transform.position;
            Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;
            StartCoroutine(TypeLine());
            if (!inCorridor && !interaction)
            {
                Invoke("RemoveLine", 5);
            }
        }
        else if (phaseChange && ! Death && !Final)
        {
            index = Random.Range(0, 5);
            if (index == repeat)
            {
                index = Random.Range(0, 5);
                startDialogue();
            }
            else
            {
                repeat = index;
                textComponent.text = string.Empty;
                Text.transform.position = tpPoints[tpPointUsed].transform.position;
                Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;
                StartCoroutine(TypeLine());
                if (!inCorridor && !interaction)
                {
                    Invoke("RemoveLine", 5);
                }
            }
            

        }
        else if (Death)
        {
            index = Random.Range(5, 10);
            StopAllCoroutines();
            textComponent.text = string.Empty;
            Text.transform.position = tpPoints[tpPointUsed].transform.position;
            Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;
            StartCoroutine(TypeLine());
            if (!inCorridor && !interaction)
            {
                Invoke("RemoveLine", 5);
            }
        }
        else if (Final && !Death)
        {
            index = Random.Range(10, 15);
            textComponent.text = string.Empty;
            Text.transform.position = tpPoints[tpPointUsed].transform.position;
            Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;
            StartCoroutine(TypeLine());
            if (!inCorridor && !interaction)
            {
                Invoke("RemoveLine", 5);
            }
        }
        else if (inCorridor)
        {
            StartCoroutine(TypeLine());
            if (!inCorridor && !interaction)
            {
                Invoke("RemoveLine", 5);
            }
        }
        else if (interaction)
        {
            StartCoroutine(TypeLine());
        }
        


    }

    IEnumerator TypeLine()
    {
        if (lines[index] == checkA)
        {
            Text.text = lines[index - 1];
            halt = true;
            button.ShowA();
        }
        else if (lines[index] == checkB)
        {
            Text.text = lines[index - 1];
            halt = true;
            button.ShowB();
        }
        else if (lines[index] == checkC)
        {
            Text.text = lines[index - 1];
            halt = true;
            button.ShowC();
        }
        else if (lines[index] == checkD)
        {

            Text.text = lines[index - 1];
            halt = true;
            button.ShowD();
        }
        else
        {
            Text.enabled = true;
            if (inCorridor)
            {
                shadowVoice.pitch = Random.Range(0.5f, 0.8f);
                shadowVoice.panStereo = Random.Range(-1, 1);
                shadowVoice.PlayOneShot(darkVoice);
            }
            if (inBoss)
            {
                shadowVoice.pitch = Random.Range(0.5f, 0.8f);
                shadowVoice.panStereo = Random.Range(-1, 1);
                shadowVoice.PlayOneShot(darkVoice);
            }
            if (Journal)
            {
                typingSource.Play();
            }
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
                if (interaction && !Journal)
                {
                    typingSource.PlayOneShot(typingSound);
                }
                
            }
        }
    }

    void NextLine()
    {
        
        if (index < lines.Length - 1)
        {
            
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            RemoveLine();
            
        }
    }
    void RemoveLine()
    {
        Text.enabled = false;
    }
    public void moveOn(int newLine)
    {
        textComponent.text = string.Empty;
        index = newLine;
        halt = false;
        StartCoroutine(TypeLine());
        arrow.SetActive(false);
    }
}

