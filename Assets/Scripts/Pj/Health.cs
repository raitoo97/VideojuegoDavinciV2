using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public HealthBar healtBar;
    //Variables de Vida mavima y actual
    public int maxHealth = 100;
    public int currentHealth;
    //Variables para el color de danio
    SpriteRenderer spriteRenderer;
    Color originalPlayerColor;

    [SerializeField] AudioClip gameOver;

    private AudioSource audiosource;
    void Start()
    {
        //Actualizo vida actual con vida maxima
        currentHealth = maxHealth;
        healtBar.SetmaxHealth(maxHealth);
        //Guardo el componente del sprite del jugador en la variable
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            //Guardo el color original del jugador
            originalPlayerColor = spriteRenderer.color;
        }

        audiosource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        print(currentHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Corrutina que me ayuda a esperar x cantidad de tiempo para cambiar de un color a otro
        StartCoroutine(ChangeColorOnDamage());
        healtBar.SetHealth(currentHealth);
        if (currentHealth<=0)
        {
            Die();
        }

    }

    /*#region 
        IEnumerator es una interfaz que define c�mo iterar sobre una colecci�n de elementos. 
        En C#, se usa en combinaci�n con yield para implementar una secuencia que puede ser iterada uno a uno. 
        Un objeto que implementa IEnumerator permite recorrer una colecci�n (como una lista o una secuencia generada por yield) 
        y acceder a sus elementos en orden.

    #endregion*/
    private IEnumerator ChangeColorOnDamage() 
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;

            /*#region 
                yield = 'devolver'
                
                Indica que una funci�n o m�todo generar� una serie de valores en lugar de devolver un solo resultado. 
                En lugar de devolver todos los resultados a la vez, yield permite que la funci�n devuelva un valor y luego reanude su ejecuci�n 
                desde el punto en el que se detuvo, permitiendo la iteraci�n perezosa.

            #endregion*/
            yield return new WaitForSeconds(0.2f);

            spriteRenderer.color = originalPlayerColor;
        }
    }

    private void Die()
    {
        Debug.Log("THE PLAYER HAS DIED");
        if (gameObject != null)
        {
            if (audiosource != null && gameOver != null)
            {
                audiosource.PlayOneShot(gameOver);
            }
            Destroy(this.gameObject);
        }
    }

   
}
