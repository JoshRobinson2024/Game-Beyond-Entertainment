using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortxAnimator : MonoBehaviour
{
    public Animator anim;
    public Collider2D vortexHit;
    public Collider2D vortexHit2;
    public Bullet bul;
    // Start is called before the first frame update
    void OnEnable()
    {
        anim.SetBool("Gone", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vortex.fadeOut)
        {
            anim.SetBool("Gone", true);
            Invoke("Remove", 2);
        }
        if (Vortex.suction)
        {
            vortexHit.enabled = true;
            vortexHit2.enabled = true;
        }
        else
        {
            vortexHit.enabled = false;
            vortexHit2.enabled = false;
        }
    }
    public void Remove()
    {
        Destroy(gameObject);
    }
}
