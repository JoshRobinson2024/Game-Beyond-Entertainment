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
            
        }
        
        else
        {
            
            index = 0;
        }

        
        
        textComponent.text = string.Empty;
        startDialogue();


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
        
    }

    void startDialogue()
    {
        if (phaseChange)
        {
            tpPointUsed = Random.Range(0, 4);

            Text.transform.position = tpPoints[tpPointUsed].transform.position;
            Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;
            
        }
        else if (Death)
        {
            tpPointUsed = Random.Range(5, 9);

            Text.transform.position = tpPoints[tpPointUsed].transform.position;
            Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;
            
        }
        else if (Final)
        {
            tpPointUsed = Random.Range(9, 14);

            Text.transform.position = tpPoints[tpPointUsed].transform.position;
            Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;
            
        }
        StartCoroutine(TypeLine());
        
        
        
    }

    IEnumerator TypeLine()
    {
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
            
            gameObject.SetActive(false);
        }
    }
}

