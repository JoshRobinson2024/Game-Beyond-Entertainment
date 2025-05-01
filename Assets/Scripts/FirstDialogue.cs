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
    private int index;
    public TMP_Text Text;
    private float movePos;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        startDialogue();
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
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            tpPointUsed = Random.Range(0, tpPoints.Count);
            Invoke("RemoveLine", 7);
            Text.transform.position = tpPoints[tpPointUsed].transform.position;
            Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;
        }
        else
        {
            
            gameObject.SetActive(false);
        }

    }
    public void RemoveLine()
    {
        textComponent.text = string.Empty;
    }
    
}

