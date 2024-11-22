using System.Collections;
using UnityEngine;
public class Bomb : MonoBehaviour
{
    public float explosionTime = 0.3f;  // Tiempo antes de la explosi�n
    public GameObject explosionEffect;  // Prefab de la explosi�n 
    public float explosionRadius = 5f;   // Radio de la explosi�n
    public float gasDamage = 0.2f;
    public LayerMask enemyLayer;  // Filtrar enemigos


    
    public void DetonateBomb()
    {
        
        StartCoroutine(ExplosionCountdown());
    }
    private IEnumerator ExplosionCountdown()
    {
        yield return new WaitForSeconds(explosionTime);
        Explode();
    }
    private void Explode()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

        }
        // Da�o por veneno
        CauseDamageInArea();
        // Destruir la bomba
        Destroy(gameObject);
    }
    private void CauseDamageInArea()
    {
        Debug.Log("CauseDamageInArea()");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyLayer);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                EnemyBehavior enemy = collider.GetComponent<EnemyBehavior>();
                if (enemy != null)
                {
                    enemy.TakePoisonDamage(gasDamage); // Ajusta el da�o por segundo
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}