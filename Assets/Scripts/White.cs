using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("White", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
