using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCooldown : MonoBehaviour
{
    public GameObject friend;
    public GameObject journal;
    public GameObject mother;
    public static int friendCoolDown;
    public static int motherCoolDown;
    public static int journalCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        if (friendCoolDown > 0)
        {
            friend.SetActive(false);
        }
        else
        {
            friend.SetActive(true);
        }
        if (journalCoolDown > 0)
        {
            journal.SetActive(false);
        }
        else
        {
            journal.SetActive(true);
        }
        if (motherCoolDown > 0)
        {
            mother.SetActive(false);
        }
        else
        {
            mother.SetActive(true);
        }
    }
    public void GainFriendCooldown()
    {
        friendCoolDown = 1;
    }
    public void GainJournalCooldown()
    {
        journalCoolDown = 2;
    }
    public void GainMotherCooldown()
    {
        motherCoolDown = 3;
    }
    public static void reduceCooldown()
    {
        friendCoolDown--;
        journalCoolDown--;
        motherCoolDown--;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
