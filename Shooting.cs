using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : Weapon
{
    public GameObject bulletPrefab;
    public override  void  Shoot()
    {
       //create bullet gameobject
       GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
       //add force to the bullet to move
       rb.AddForce(firePoint.up * weaponForce, ForceMode2D.Impulse);

       //destroy the bullet after time 2f 
       Destroy(bullet, 1);
    }

}
