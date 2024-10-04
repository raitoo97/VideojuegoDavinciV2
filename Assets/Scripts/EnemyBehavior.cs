using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    public int damage = 10;
    public int speed = 3;
    public GameObject materialPrefab;
    [SerializeField] float chaseDistance = 5.5f;
    bool canMove;
    GameObject player;

    private void Start()
    {
        player = GameManager.instance.player;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
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


