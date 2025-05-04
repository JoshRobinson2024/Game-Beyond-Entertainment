using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionLineAttack : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float spacing;
    public int explosionCount = 6;
    public Spawner spawner;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void ExecuteExplosionLineAttack()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        spacing = direction.magnitude / 6;

        for (int i = 1; i <= explosionCount; i++)
        {
            
            StartCoroutine(SpawnExplosionsWithDelay(direction));
        }
    }
    

    IEnumerator SpawnExplosionsWithDelay(Vector2 direction)
    {
        for (int i = 1; i <= explosionCount; i++)
        {
            Vector2 spawnPosition = (Vector2)transform.position + direction * spacing * i;
            Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.1f); // Delay between explosions
            if (i == explosionCount)
            {
                spawner.wait();
            }
        }
        
    }
}
