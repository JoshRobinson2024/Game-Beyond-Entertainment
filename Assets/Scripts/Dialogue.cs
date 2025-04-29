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
    // Start is called before the first frame update
    void Start()
    {
        if (inCorridor)
        {
            index = Random.Range(0, lines.Length);
            tpPointUsed = Random.Range(0, tpPoints.Count);
            
            Text.transform.position = tpPoints[tpPointUsed].transform.position;
            Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;
            Invoke ("startDialogue", 2);
        }
        
        else
        {
            
            index = 0;
        }

        
        
        textComponent.text = string.Empty;
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && interaction)
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
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
        
        


    }

    IEnumerator TypeLine()
    {
        Text.enabled = true;
        if (!interaction)
        {
            shadowVoice.PlayOneShot(darkVoice);
        }
        
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
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
}

