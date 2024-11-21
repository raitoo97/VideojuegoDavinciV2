using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] private float coolDown;
    private float nextShootTime;
    public bool IsCoolingDown => Time.time < nextShootTime;
    public int shoots = 6;

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
        if (IsCoolingDown == false)
        {
            if (this != null)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = bulletSpawn.position;
                bullet.transform.up = (target.transform.position - bulletSpawn.position).normalized;
            }
            shoots--;
            if (shoots == 0)
            {
                nextShootTime = Time.time + coolDown;
            }
        }
                      
    }
   

}
