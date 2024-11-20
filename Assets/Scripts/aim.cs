using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
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
            bulletSpawn.transform.position = target.transform.position;
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.up = (target.transform.position - bulletSpawn.position).normalized;
        }
    }
}
