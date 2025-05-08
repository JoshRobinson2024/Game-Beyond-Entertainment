using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject textBox;
    public string[] lines;
    public float textSpeed;
    public TMP_Text text; 
    private int index;
    public PlayerMovement mov;
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(false);
        mov.locked = true;
        textComponent.text = string.Empty;
        startDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (textComponent.text == lines[index])
        {
            arrow.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
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
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
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
            arrow.SetActive(false);
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            arrow.SetActive(false);
            mov.locked = false;
            textBox.SetActive(false);
            textComponent.text = string.Empty;
        }
    }
}

