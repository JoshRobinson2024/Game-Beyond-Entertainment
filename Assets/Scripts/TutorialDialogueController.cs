using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

using Unity.VisualScripting;
using UnityEngine.UIElements;

public class TutorialDialogueController : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public SceneManagement manager;
    public string[] lines;
    public float textSpeed;
    public GameObject Will;
    public AudioSource shadowVoice;
    public AudioClip darkVoice;
    public int index;
    public TMP_Text Text;
    public GameObject controller;
    public GameObject Guitar;
    public GameObject Journal;
    public string SpawnWillImage;
    public string DespawnWillImage;
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
    public GameObject arrow;
    public PlayerMovement mov;
    
    private void Start()
    {
        mov.locked = true;
        arrow.SetActive(false);
        index = 0;
        Invoke("startDialogue", 0.1f);
        textComponent.text = string.Empty;
    }
    private void Update()
    {
        if (textComponent.text == lines[index] && !dashCheck && !PickedupCheck && !movedCheck && !thrownCheck && !(lines[index] == Throw))
        {
            arrow.SetActive(true);
            
        }
        if (mov.locked)
        {
            if (Input.GetMouseButtonDown(0))
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
        if (dashed && dashCheck)
        {
            
            dashed = false;
            Invoke("NextLine", 1.7f);
        }
        if (thrownCheck && thrown)
        {
             
            thrown = false;
            Invoke("NextLine", 0.2f);
        }
        if (moved && movedCheck && ObjectGrab.grabbed)
        {
            moved = false;
            ObjectGrab.grabbed = false;
            
            Invoke("locking", 2.5f);
        }
        if(Pickedup && PickedupCheck)
        {
            Pickedup = false;

            NextLine();
        }
    }
    public void locking()
    {
        mov.locked = true;
        Invoke("NextLine", 0.5f);
    }
    public void startDialogue()
    {
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;
        if (lines[index] == spawnController)
        {
            controller.SetActive(true);
        }
        if(lines[index] == spawnObjects)
        {
            Guitar.SetActive(true);
            Journal.SetActive(true);
        }
        if (lines[index] == SpawnWillImage)
        {
            Will.SetActive(true);
        }
        if (lines[index] == DespawnWillImage)
        {
            Will.SetActive(false);
        }
        if (lines[index] == dash)
        {
            dashCheck = true;
            mov.locked = false;
        }
        else
        {
            dashCheck = false;
            
        }
        if (lines[index] == Pickup)
        {
            PickedupCheck = true;
            mov.locked = false;
        }
        else
        {
            
            PickedupCheck = false;
        }
        if (lines[index] == Move)
        {
            movedCheck = true;
            mov.locked = false;
        }
        else
        {
            movedCheck = false;
            
        }
        if (lines[index] == Throw)
        {
            
            Invoke("throwCheckUnlock", 1);
        }
        else
        {
            thrownCheck = false;
        }
        Debug.Log(index);
        shadowVoice.pitch = Random.Range(1.3f, 1.65f);
        
        shadowVoice.panStereo = Random.Range(-1f, 1f);
        shadowVoice.PlayOneShot(darkVoice);
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
            

        }
    }
    public void throwCheckUnlock()
    {
        thrownCheck = true;
        mov.locked = false;
    }
    public void NextLine()
    {
        

        if (index < lines.Length - 1)
        {
            mov.locked = true;
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (!movedCheck)
            {
                manager.loadInteractionSelect();
            }
            

        }
    }
}    



