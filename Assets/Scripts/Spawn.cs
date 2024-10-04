using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawn;
    [SerializeField] float spawnTime;
    bool onRange;
    float spawnTimer;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Cooldown();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) return;
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealt = collision.gameObject.GetComponent<Health>();
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (playerHealt != null)
            {
                playerHealt.TakeDamage(10);
                player.TakeKnockback(transform.up * 12);
            }
        }
    }
    #region Spawn
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!collision.gameObject.CompareTag("Player")) return;
         
        onRange = true;
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = enemySpawn.position;
        
        Vector2 enemyMovement = enemy.transform.position;
        enemyMovement.x = Random.Range(-6,6);
        enemy.transform.position = enemyMovement;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        onRange = false;
    }
    #endregion
    void Cooldown()
    {
        if (!onRange) return;
        spawnTimer = Time.deltaTime;
        if (spawnTimer >= spawnTime)
        {
            onRange= false;
            spawnTimer= 0;
        }

    }
}
