using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstDialogueController : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    
    public string[] lines;
    public float textSpeed;
    public List<GameObject> tpPoints;
    private int tpPointUsed;
    public AudioSource shadowVoice;
    public AudioClip darkVoice;
    public int index;
    public TMP_Text Text;
    private float movePos;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        PlayerMovement.maxHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        tpPointUsed = Random.Range(0, tpPoints.Count);

        Text.transform.position = tpPoints[tpPointUsed].transform.position;
        Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;

        Invoke("RemoveLine", 7);
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
        
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
        tpPointUsed = Random.Range(0, tpPoints.Count);
        if (index == 3)
        {
            Invoke("RemoveLine", 4);
        }
        else 
        {
            Invoke("RemoveLine", 7);
        }
        
        Text.transform.position = tpPoints[tpPointUsed].transform.position;
        Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;


    }
    public void RemoveLine()
    {
        if(index == 3)
        {
            index = 4;
            NextLine();
        }
        else
        {
            textComponent.text = string.Empty;
        }
        
    }
    
}

