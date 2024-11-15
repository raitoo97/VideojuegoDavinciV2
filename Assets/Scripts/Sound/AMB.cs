using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMB : MonoBehaviour
{
    //referencia
    private AudioSource audioSource;

    private void Awake()
    {
        //Si el objeto no tiene el componente, devuelve null. Si lo tiene lo guardo en la referencia.
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
            {
                audioSource.Play();
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}
