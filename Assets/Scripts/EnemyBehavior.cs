using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int damage = 10;
    [SerializeField] int speed = 3;
    [SerializeField] float chaseDistance = 5.5f;
    [SerializeField] float knockback = 17.2f;
    bool canMove;
    GameObject player;
    public GameObject materialPrefab;

    private void Start()
    {
        player = GameManager.instance.player;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (player != null)
        {
            if (Vector2.Distance(this.transform.position, player.transform.position) <= chaseDistance)
            {
                canMove = true;
                transform.up = (player.transform.position - this.transform.position).normalized;
            }
            else
            {
                canMove= false;
            }

            if (canMove) 
            {
                rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (playerHealth != null) 
            {
                playerHealth.TakeDamage(damage);
                player.TakeKnockback(transform.up * knockback);
            }
        }
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


