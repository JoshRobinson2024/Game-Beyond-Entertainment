using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimatorControl : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void wave()
    {
        anim.SetBool("Waving", true);
    }
    public void stopWaving()
    {
        anim.SetBool("Waving", false);
    }
}
