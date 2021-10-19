using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public float x = 0; //where to teleport player in x
    public float y = 0; //where to teleport player in y
    public Text countText;//get the counter text
    public bool turnTrue; 
    // Start is called before the first frame update
    void Start()
    {
        countText = GameObject.Find("Count").GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //teleport player if he collides to the other level and update objective
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector3(x, y, 0); // teleport player
            GameObject.Find("Hero").GetComponent<PlayerHealth>().isLevel2 = turnTrue; //make player isLevel2 true or false based on which portal is taken
            GameObject.Find("Hero").GetComponent<PlayerHealth>().InvokeTakeDamage(); // start losing health if in snow without coat 
            setScore();
        }

    }

    public void setScore()
    {
        //update counter based on the number of Enemies left
        int strongGeese = GameObject.FindGameObjectsWithTag("StrongEnemy").Length;
        int shootingEnemy = GameObject.FindGameObjectsWithTag("ShootingEnemy").Length;

        //set objective
        if (strongGeese + shootingEnemy <= 0)
        {
            countText.text = "You Killed All Enemies!";

        }
        else
            countText.text = "Strong Geese Remaining: " + strongGeese.ToString() +"\nShooting Enemy Remaining: " + shootingEnemy;


    }


}