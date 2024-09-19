using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    SpriteRenderer spriteRenderer;
    Color originalPlayerColor;

    void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            originalPlayerColor = spriteRenderer.color;
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(ChangeColorOnDamage());

        if (currentHealth<=0)
        {
            Die();
        }

    }

    private IEnumerator ChangeColorOnDamage() 
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;

            yield return new WaitForSeconds(0.2f);

            spriteRenderer.color = originalPlayerColor;
        }
    }

    private void Die()
    {
        Debug.Log("THE PLAYER HAS DIED");
    }
   
}
