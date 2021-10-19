using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyScript : MonoBehaviour
{
    public float speed; // variable for the speed 
    public Text countText; //get the counter text
    public GameObject portal;
    public GameObject coin;
    private Transform _target;
    public float health;

    // Start is called before the first frame update
    public virtual void Awake()
    {
        //get the count text and set it to countText
        countText = GameObject.Find("Count").GetComponent<Text>();
        //initialize the text to the number of enemies
        setScore(GameObject.FindGameObjectsWithTag("Enemy").Length);
    }


    //setter and getter for target position
    public Transform targetPos {
        get {
            return _target;
        }
        set {
            _target = value;
        }
    }


    //call function when collider is triggered
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //if the collision is triggered by hero weapon/mine then deal damage to the enemy gameobject
        if (collision.gameObject.CompareTag("Weapon"))
        {
            //reduce health when hit
            health -= 10;
            //destroy weapon object
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("Mine"))
        {
            health -= 20;

            collision.GetComponentInChildren<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = collision.GetComponentInChildren<ParticleSystem>().emission;
            em.enabled = true;

            Destroy(collision.gameObject, 1);
        }

        //if the enemy health is 0 then destroy the enemy and spawn a coin
        if (health <= 0) {
            
            Instantiate(coin, transform.position, Quaternion.identity); 
            //destroy this enemy and set the score. 
            Destroy(gameObject);
            //update the score counter
            setScore();
        }
    }


    public void setScore(int score) {
        //update counter based on the argument given
        countText.text = "Geese Remaining: " + score.ToString();
    }

    public virtual void setScore()
    {
        
        int score = GameObject.FindGameObjectsWithTag("Enemy").Length - 1;
        if (score <= 0) {
            //if the hero kills all geese in level 1 then give them hint that level 2 portal is open
            countText.text = "A portal has been open to level 2";
            Instantiate(portal, new Vector2(-35f, 33.6f), Quaternion.identity);
        }else
            //update counter based on the number of Enemies left
            countText.text = "Geese Remaining: " + score.ToString();


    }

}
