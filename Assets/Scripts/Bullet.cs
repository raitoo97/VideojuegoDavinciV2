using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifetime;
    void Start()
    {
      //  Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || (collision.CompareTag("Wall")))
        {
          //  Destroy(gameObject);
        }

    }*/
}

