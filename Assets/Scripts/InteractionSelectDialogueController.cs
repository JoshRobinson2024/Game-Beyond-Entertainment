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
    public Canvas house;
    public Canvas school;
    private static int canvasChosen;
    // Start is called before the first frame update
    void Start()
    {
        if (canvasChosen == 0)
        {
            house.enabled = true;
            SceneManagement.friendSceneToLoad = "Friend";
            SceneManagement.motherSceneToLoad = "Parent";
            SceneManagement.journalSceneToLoad = "Journal";
        }
        else
        {
            SceneManagement.friendSceneToLoad = "Friend 1";
            SceneManagement.motherSceneToLoad = "Parent 1";
            SceneManagement.journalSceneToLoad = "Journal 1";
            school.enabled = true;
        }
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
            canvasChosen = Random.Range(0, 4);
            if (canvasChosen == 0)
            {
                house.enabled = true;
                SceneManagement.friendSceneToLoad = "Friend";
                SceneManagement.motherSceneToLoad = "Parent";
                SceneManagement.journalSceneToLoad = "Journal";
            }
            else if (canvasChosen == 1)
            {
                SceneManagement.friendSceneToLoad = "Friend 1";
                SceneManagement.motherSceneToLoad = "Parent 1";
                SceneManagement.journalSceneToLoad = "Journal 1";
                school.enabled = true;
            }
            else if (canvasChosen == 2)
            {
                house.enabled = true;
                SceneManagement.friendSceneToLoad = "Friend 2";
                SceneManagement.motherSceneToLoad = "Parent 2";
                SceneManagement.journalSceneToLoad = "Journal 2";
            }
            else if (canvasChosen == 3)
            {
                SceneManagement.friendSceneToLoad = "Friend 3";
                SceneManagement.motherSceneToLoad = "Parent 3";
                SceneManagement.journalSceneToLoad = "Journal 3";
                school.enabled = true;
            }
            index = Random.Range(0, 7);
            textComponent.text = string.Empty;
            textComponent.text = lines[index];
            Debug.Log("Day number: " + dayNumber);
        }
        
    }
    

    

    
    
    
}

