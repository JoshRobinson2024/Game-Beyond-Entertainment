using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionSelectDialogueController : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    
    public string[] lines;
    public float textSpeed;

    public static bool changeLine;
    public static int dayNumber;
    public int index;
    public TMP_Text Text;
    
    // Start is called before the first frame update
    void Start()
    {
        
        randomise();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void randomise()
    {
        if (changeLine)
        {
            index = Random.Range(0, 7);
            textComponent.text = string.Empty;
            textComponent.text = lines[index];
            Debug.Log("Day number: " + dayNumber);
        }
        
    }
    

    

    
    
    
}

