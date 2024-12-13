using System.Collections;
using UnityEngine;
public class PowerUp_Bombs : MonoBehaviour
{
    
    public GameObject pickupEffect;
    public float multp = 1.1f;
    public float duration = 3f;
    private AudioSource audioSource;
    [SerializeField] AudioClip pickUp;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Bomb.explosionRadius = 1.5f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null && pickUp != null)
            {
                audioSource.PlayOneShot(pickUp);
            }
            Bomb.explosionRadius = Bomb.explosionRadius * multp;
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
