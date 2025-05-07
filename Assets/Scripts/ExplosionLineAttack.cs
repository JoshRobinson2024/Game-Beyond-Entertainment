using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionLineAttack : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float spacing;
    public int explosionCount = 6;
    public bool lineAttack;
    public bool RandomAttack;
    public bool FollowAttack;
    private Transform player;
    public GameObject[] tpPoints;
    private int tpSelected;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (BossHealth.victory)
        {
            StopAllCoroutines();
        }
    }
    public void ExecuteExplosionLineAttack()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        spacing = direction.magnitude / 6;
        spacing = spacing * 50;

        
        
            
        StartCoroutine(SpawnExplosionsWithDelay(direction));
        
    }
    

    IEnumerator SpawnExplosionsWithDelay(Vector2 direction)
    {
        for (int i = 1; i <= explosionCount; i++)
        {
            if (lineAttack)
            {
                Vector2 spawnPosition = (Vector2)transform.position + direction * spacing * i;
                Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(0.5f); // Delay between explosions
            }
            else if (RandomAttack)
            {
                tpSelected = Random.Range(0, tpPoints.Length);
                Instantiate(explosionPrefab, tpPoints[tpSelected].transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f); // Delay between explosions
            }
            else if (FollowAttack)
            {
                Instantiate(explosionPrefab, player.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1.35f); // Delay between explosions

            }
            
            
        }
        
    }
}
