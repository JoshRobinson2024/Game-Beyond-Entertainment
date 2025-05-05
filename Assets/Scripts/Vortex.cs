using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    
    public GameObject vortex;
    public static GameObject currentVortex;
    public GameObject[] tpPoints;
    private int tpSelected;

    private float wait;
    
    public static bool suction;
    
    public void spawnVortex()
    {
        tpSelected = Random.Range(0, tpPoints.Length);
        wait = Random.Range(8.5f, 16.5f);
        currentVortex = Instantiate(vortex, tpPoints[tpSelected].transform.position, Quaternion.identity);
        Invoke("beginSuction", 1.5f);
        Invoke("endSuction", wait);
    }
    public void beginSuction()
    {
        suction = true;
    }
    public void endSuction()
    {
        suction = false;
    }
    
    
}
