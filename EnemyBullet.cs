using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet : EnemyScript
{
    public override void Awake()
    {
        //get the count text
        countText = GameObject.Find("Count").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //destroy the enemy bullet after 5 seconds
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //make the bullet follow the player
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  // assign target to the player object transformation
        transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);

    }

    //call function when collider is triggered
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collision is triggered by the hero then destroy the enemy gameobject
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject,0.1f);
        }
    }

    public override void setScore()
    {
        //update counter based on the number of Enemies left
        int strongGeese = GameObject.FindGameObjectsWithTag("StrongEnemy").Length;
        int shootingEnemy = GameObject.FindGameObjectsWithTag("ShootingEnemy").Length;


        if (strongGeese + shootingEnemy <= 0)
        {
            countText.text = "You Killed All Enemies!";

        }
        else
            countText.text = "Strong Geese Remaining: " + strongGeese.ToString() + "\nShooting Enemy Remaining: " + shootingEnemy;
    }
}