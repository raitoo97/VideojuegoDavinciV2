using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifetime;
    void Start()
    {
        Destroy(gameObject, lifetime);

    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
