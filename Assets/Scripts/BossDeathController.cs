using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathController : MonoBehaviour
{
    public GameObject anim;
    public GameObject[] tpPoints;
    private int tpSelected;
    public GameObject explosionPrefab;
    public bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BossAura()
    {
        anim.SetActive(true);

    }
    public void explode()
    {
        tpSelected = Random.Range(0, tpPoints.Length);
        Instantiate(explosionPrefab, tpPoints[tpSelected].transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if (BossHealth.victory && once)
        {
            once = false;
            Invoke("BossAura", 8f);
            InvokeRepeating("explode", 0, 0.3f);
        }
    }
}
