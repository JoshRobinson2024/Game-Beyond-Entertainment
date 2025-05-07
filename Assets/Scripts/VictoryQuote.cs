using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryQuote : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    
    public string[] lines;
    public float textSpeed;
    
    public AudioSource shadowVoice;
    public AudioClip darkVoice;
    public int index;
    public TMP_Text Text;
    private float movePos;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    IEnumerator TypeLine()
    {
        shadowVoice.pitch = Random.Range(1.2f, 1.5f);
        shadowVoice.panStereo = Random.Range(-1f, 1f);
        shadowVoice.PlayOneShot(darkVoice);
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void ShowText()
    {
        StartCoroutine(TypeLine());
        


    }
    
}

