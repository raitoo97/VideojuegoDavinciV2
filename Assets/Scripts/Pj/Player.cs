using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] GameObject target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;

    public int materialCount = 0;
    void Start()

    {
        InputManager.instance.interactAction += Shoot;
    }
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 fixedMousepos = new Vector3(mousePos.x, mousePos.y, 0);
        target.transform.position = fixedMousepos;
    }
    void FixedUpdate()
    {
        transform.up = (target.transform.position - transform.position).normalized;
    }
    void Shoot()
    {
        if (this != null)
        {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.up = (target.transform.position - bulletSpawn.position).normalized;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Material"))
        {
            materialCount++;
        }
    }
}
