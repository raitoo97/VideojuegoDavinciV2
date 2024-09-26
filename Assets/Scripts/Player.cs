using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 fixedMousepos = new Vector3(mousePos.x, mousePos.y, 0);
        target.transform.position = fixedMousepos;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        transform.up = (target.transform.position - transform.position).normalized;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.up = (target.transform.position - bulletSpawn.position).normalized;
    }
}
