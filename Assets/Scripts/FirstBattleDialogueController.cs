using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstbattleDialogueController : MonoBehaviour
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
    public PlayerMovement mov;
    public string CheckA;
    public string CheckB;
    public Spawner boss;
    public Animator tp;
    public SpriteRenderer BossSprite;
    // Start is called before the first frame update
    void Start()
    {
        BossSprite.enabled = false;

        textComponent.text = string.Empty;
        mov.locked = true;
        boss.locked = true;
        Invoke("startDialogue", 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void startDialogue()
    {
        BossSprite.enabled = true;
        index = 0;
        StartCoroutine(TypeLine());
        tpPointUsed = Random.Range(0, tpPoints.Count);

        Text.transform.position = tpPoints[tpPointUsed].transform.position;
        Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;

        Invoke("NextLine", 3);
    }

    IEnumerator TypeLine()
    {
        shadowVoice.pitch = Random.Range(0.5f, 0.8f);
        shadowVoice.panStereo = Random.Range(-1f, 1f);
        shadowVoice.PlayOneShot(darkVoice);
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    public void RemoveDash()
    {
        mov.dash = false;
        Invoke("NextLine", 2);
        Invoke("appear",3);
    }
    public void dash()
    {
        mov.dash = true;
    }
    public void appear()
    {
        tp.SetBool("TeleportExit", false);
        tp.SetBool("TeleportEnter", true);
        Invoke("tpreset", 0.01f);
    }
    public void tpreset()
    {
        tp.SetBool("TeleportEnter", false);
    }
    public void NextLine()
    {

        textComponent.text = string.Empty;
        index++;
        
        tpPointUsed = Random.Range(0, tpPoints.Count);
        if (lines[index]==CheckA)
        {
            boss.bulletDodge();

            Invoke("dash", 1);
            Invoke("RemoveDash", 1.7f);
            

            
        }
        else if (lines[index] == CheckB)
        {
            mov.locked = false;
            boss.locked = false;
            tp.SetBool("teleportExit", false);
            tp.SetBool("TeleportEnter", true);
            mov.MusicStart();
        }
        else
        {

            StartCoroutine(TypeLine());
            Invoke("NextLine", 3);
        }

        Text.transform.position = tpPoints[tpPointUsed].transform.position;
        Text.transform.rotation = tpPoints[tpPointUsed].transform.rotation;


    }
    public void RemoveLine()
    {
        if (index == 3)
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

