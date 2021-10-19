using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    //if the bullet hits something other than the enemies or hero then destroy the bullet
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyPoo") || collision.gameObject.CompareTag("ShootingEnemy") || collision.gameObject.CompareTag("StrongEnemy")|| collision.gameObject.CompareTag("Player"))
        {
        }
        else
            Destroy(gameObject);
    }
}
