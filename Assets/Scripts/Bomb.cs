using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float detonationTime = 0.1f;  // Tiempo antes de la explosión
    public float explotionTime = 4f;
    public GameObject explosionEffect;  // Prefab de la explosión
    public float gasDamage = 100f;
    public float explosionRadius = 2f;   // Radio de la explosión
    [SerializeField] private GameObject explosionRadiusIndicator; // El prefab del indicador del radio de la explosión
    private GameObject explosionEffectIndicator;

    public LayerMask enemyLayer;  // Filtrar enemigos

    private void Start()
    {
        // Instanciar el indicador de radio de la explosión
        explosionEffectIndicator = Instantiate(explosionRadiusIndicator, transform.position, Quaternion.identity);

        // Asegúrate de que el indicador esté posicionado correctamente
        explosionEffectIndicator.transform.position = transform.position;

        // Ajustar la escala del indicador según el radio
        explosionEffectIndicator.transform.localScale = new Vector3(explosionRadius * 2, explosionRadius * 2, 1);

        
    }

    public void DetonateBomb()
    {
        StartCoroutine(ExplosionCountdown());   
    }

    private IEnumerator ExplosionCountdown()
    {
        yield return new WaitForSeconds(detonationTime);
        Explode();
    }

    private void Explode()
    {
        StartCoroutine(EffectBomb());
        
    }
    private IEnumerator EffectBomb() 
    {
        // Crear el efecto de explosión
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Causar daño en el área de la explosión
        CauseDamageInArea();

        yield return new WaitForSeconds(explotionTime);
        // Destruir la bomba
        Destroy(gameObject);
        Destroy(explosionEffectIndicator);
    }
    private void CauseDamageInArea()
    {
        // Detectar enemigos dentro del radio de la explosión
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyLayer);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                EnemyBehavior enemy = collider.GetComponent<EnemyBehavior>();
                if (enemy != null)
                {
                    enemy.TakePoisonDamage(gasDamage); // Ajustar el daño por veneno
                }
            }
        }
    }

}