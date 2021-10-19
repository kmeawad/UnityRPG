using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : EnemyScript
{
    public Transform firePoint; // get the position of the firepoint where the bullet will come out  of the player
    public GameObject player;
    public float cooldown = 1f; // cooldown for how often the enemy shoots bullet
    public GameObject bulletPrefab;

    public float weaponForce = 20f;

    private float _timeRemaining;



    // Start is called before the first frame update
    void Start()
    {
        _timeRemaining = 0;
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  // assign target to the player object transformation
    }

    // Update is called once per frame
    void Update()
    {
        // if the distance between the object and the target objecct less than 15 then shoot
        if (Vector2.Distance(transform.position, targetPos.position) < 15f)
        { 
            //make sure that cooldown has finished before shooting again
            if (_timeRemaining <= 0)
            {
                //create bullet gameobject
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                _timeRemaining = cooldown;
            }
            else
                _timeRemaining -= Time.deltaTime; // reduce the time remaining for the next bullet to shoot
        }
    }

    //update counter based on the number of Enemies left
    public override void setScore()
    {
        
        int strongGeese = GameObject.FindGameObjectsWithTag("StrongEnemy").Length;
        int shootingEnemy = GameObject.FindGameObjectsWithTag("ShootingEnemy").Length - 1;


        if (strongGeese + shootingEnemy <= 0)
        {
            //if all enemies were destroyed then display that player beat the game
            countText.text = "You Beat The Game!";

        }
        else
            countText.text = "Strong Geese Remaining: " + strongGeese.ToString() + "\nShooting Enemy Remaining: " + shootingEnemy; 
    }

}
