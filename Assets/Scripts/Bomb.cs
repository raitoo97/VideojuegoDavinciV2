using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float detonationTime = 0.1f;  // Tiempo antes de la explosi�n
    public float explotionTime = 4f;
    public GameObject explosionEffect;  // Prefab de la explosi�n
    public float gasDamage = 100f;
    public static float explosionRadius = 1.5f;   // Radio de la explosi�n
    [SerializeField] private GameObject explosionRadiusIndicator; // El prefab del indicador del radio de la explosi�n
    private GameObject explosionEffectIndicator;

    public LayerMask enemyLayer;  // Filtrar enemigos


    void Start()
    {
        explosionEffectIndicator = Instantiate(explosionRadiusIndicator, transform.position, Quaternion.identity);
        explosionEffectIndicator.transform.position = transform.position;
        explosionEffectIndicator.transform.localScale = new Vector3(explosionRadius, explosionRadius, 1);
        // A�adir CircleCollider2D para detectar los enemigos dentro del radio
        var collider = explosionEffectIndicator.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;
        collider.radius = explosionRadius;
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
        // Crear el efecto de explosi�n
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Causar da�o en el �rea de la explosi�n
       // CauseDamageInArea();

        yield return new WaitForSeconds(explotionTime);
        // Destruir la bomba
        Destroy(gameObject);
        Destroy(explosionEffectIndicator);
    }
    /*
    private void CauseDamageInArea()
    {
        // Detectar enemigos dentro del radio de la explosi�n
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyLayer);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                EnemyBehavior enemy = collider.GetComponent<EnemyBehavior>();
                if (enemy != null)
                {
                    enemy.TakePoisonDamage(gasDamage); // Ajustar el da�o por veneno
                }
            }
        }
    }
    */

   

       void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Enemy"))
            {
                EnemyBehavior enemy = collider.GetComponent<EnemyBehavior>();
                if (enemy != null)
                {
                    enemy.TakePoisonDamage(gasDamage); // Ajustar el da�o por veneno
                }
            }
        }

  //public float EXPLOSIONRAIUDS { set => explosionRadius = value; }


}