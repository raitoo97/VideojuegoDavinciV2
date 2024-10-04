using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    public int materialCount = 0;
    public bool megaShoot = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 fixedMousepos = new Vector3(mousePos.x, mousePos.y, 0);
        target.transform.position = fixedMousepos;
       /* if (materialCount == 5)//para habilitar un disparo + potente
        {
            megaShoot = true;
        }
        else
        {
            megaShoot = false;
        }*/


        if (Input.GetMouseButtonDown(0))
        {
            Shoot(megaShoot);
        }
    }

    void FixedUpdate()
    {
        transform.up = (target.transform.position - transform.position).normalized;
    }

    void Shoot(bool shoot)
    {
        GameObject bullet = Instantiate(bulletPrefab);
     /*   if (shoot == true)
        {
            //bullet;

        }*/
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.up = (target.transform.position - bulletSpawn.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Material"))
        {
            materialCount++;
           
        }
    }

   

}
