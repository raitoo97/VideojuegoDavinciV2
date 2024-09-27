using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    int damage = 10;
    public GameObject materialPrefab;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null) 
            {
                playerHealth.TakeDamage(damage);
            }
        }

        

        dropMaterial();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            dropMaterial();
            Destroy(gameObject);
        }
    }
    void dropMaterial()
    {
        int randomInt = Random.Range(1, 5);

        // Instancia el prefab "Material" en el lugar donde el enemigo muere
        GameObject materialObject = Instantiate(materialPrefab, transform.position, Quaternion.identity);

        // Accede al componente Material para cambiar el tipo
        Material materialDropped = materialObject.GetComponent<Material>();

        if (materialDropped != null)
        {
            materialDropped.OnCreatedMaterial(randomInt);
        }
    }
}


