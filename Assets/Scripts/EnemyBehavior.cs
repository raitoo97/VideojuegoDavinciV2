using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject healthBarPrefab;
    private GameObject healthBarInstance;
    private EnemyHealthBar healthBar;

    [SerializeField] float hitPoints = 100;
    [SerializeField] int damage = 10;
    [SerializeField] int speed = 9;
    [SerializeField] float chaseDistance = 5.5f;
    [SerializeField] float knockback = 5.2f;
    public GameObject materialPrefab;
    Rigidbody2D rb;
    bool canMove;
    GameObject player;

    //Variables para el veneno
    private bool isPoisoned = false;
    private float poisonDuration = 0f;

    private void Start()
    {
        //UI Barra de Vida
        healthBarInstance = Instantiate(healthBarPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        healthBar = healthBarInstance.GetComponent<EnemyHealthBar>();
        healthBarInstance.transform.SetParent(GameManager.instance.uiCanvas.transform, false); // Si usas un canvas central

        player = GameManager.instance.player;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (hitPoints<=0)
        {
            Destroy(healthBarInstance);
            Destroy(gameObject);
        }
        else
        {
            healthBarInstance.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 1.5f);
            healthBar.UpdateHealthBar(hitPoints, 100);
        }
    }
    private void FixedUpdate()
    {
        
        //Persigue al jugador
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
        //Numero aleatorio a partir de la lista Enum 
        int randomType = Random.Range(0, System.Enum.GetValues(typeof(Material.MATERIALS)).Length);

        // Instancia el prefab "Material" en el lugar donde el enemigo muere
        GameObject materialObject = Instantiate(materialPrefab, transform.position, Quaternion.identity);

        // Accede al componente Material para cambiar el tipo
        Material materialDropped = materialObject.GetComponent<Material>();

        if (materialDropped != null)
        {
            materialDropped.OnCreatedMaterial((Material.MATERIALS)randomType);
            
        }
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        return;
    }

    public void TakePoisonDamage(float poisonDamagePerSecond)
    {
        Debug.Log("TAKEPOISONDAMAGE()");
        if (!isPoisoned) // Solo iniciar si no está ya envenenado
        {
            isPoisoned = true;
            poisonDuration = 3f; // Duración del veneno (puedes cambiar este valor o pasarlo como parámetro)
            StartCoroutine(ApplyPoisonOverTime(poisonDamagePerSecond));
        }
    }

    public IEnumerator ApplyPoisonOverTime(float poisonDamagePerSecond) 
    {
        float elapsedTime = 0f;

        while (elapsedTime < poisonDuration)
        {
            Debug.Log($"Recibi danio por {poisonDamagePerSecond}");
            hitPoints -= poisonDamagePerSecond;
            elapsedTime += 1f;
            yield return new WaitForSeconds(1f);
        }

        isPoisoned = false;
    }
}


