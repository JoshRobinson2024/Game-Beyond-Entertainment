using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimatorControl : MonoBehaviour
{
    public Animator anim;

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

    public void ult()
    {
        anim.SetBool("Ult", true);
    }
    public void stopUlt()
    {
        anim.SetBool("Ult", false);
    }
    private void Update()
    {
        if (BossHealth.victory)
        {
            anim.SetBool("Dead", true);
        }
    }
}
