using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // store the max health of the player
    public int currentHealth; // store current health of the player
    public GameObject enemy;
    public GameObject poop;
    public GameObject shooter;
    public GameObject strong;
    public Text countText;
    public HealthBar healthBar;
    public bool wearingCoat = false;
    public bool isLevel2 = false;
    private float _timeRemaining;

    private int _numOfTimesDead = 0;
    // Start is called before the first frame update
    void Start()
    {
        _timeRemaining = 0f;
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //timer so that player can have time to recover before losing more health
        if ((int)_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if ((int)_timeRemaining <= 0)
        {
            //if an enemy hits this gameobject reduce health 
            if (collision.gameObject.CompareTag("StrongEnemy"))
                TakeDamage(30);
            if (collision.gameObject.CompareTag("Enemy"))
                TakeDamage(20);
            if (collision.gameObject.CompareTag("EnemyPoo"))
                TakeDamage(10);
            if (collision.gameObject.CompareTag("EnemyBullet"))
                TakeDamage(20);
            if (collision.gameObject.CompareTag("ShootingEnemy"))
                TakeDamage(10);
            if (collision.gameObject.CompareTag("Heal"))
                if(currentHealth < maxHealth) // if the current health hasn't reached the max possible health then continue healing 
                    TakeDamage(-10);
           
            //add time for cooldown so that player does not loose all health immediately
            _timeRemaining = 1.8f;
            
        }
        //Destroy game object when health reaches 0
        if (currentHealth <= 0)
        {
            isLevel2 = false; // set isLevel 2 back to false
            Destroy(GameObject.Find("portal(Clone)")); // destroy the portal 
            _numOfTimesDead++; // increment the number of times dead
            maxHealth += _numOfTimesDead * 10; // increase the max health everytime player dies
            currentHealth = maxHealth;
            healthBar.setMaxHealth(maxHealth);
            TakeDamage(0);
            gameObject.transform.position = new Vector2(-1f, -2f);

            //Destroy all enemy objects
            GameObject[] enemypoop = GameObject.FindGameObjectsWithTag("EnemyPoo");
            for (int i = 0; i < enemypoop.Length; i++)
            {
                Destroy(enemypoop[i]);
            }
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i]);
            }
            GameObject[] shootingEnemy = GameObject.FindGameObjectsWithTag("ShootingEnemy");
            for (int i = 0; i < shootingEnemy.Length; i++)
            {
                Destroy(shootingEnemy[i]);
            }
            GameObject[] strongEnemy = GameObject.FindGameObjectsWithTag("StrongEnemy");
            for (int i = 0; i < strongEnemy.Length; i++)
            {
                Destroy(strongEnemy[i]);
            }
            GameObject[] coin = GameObject.FindGameObjectsWithTag("Coin");
            for (int i = 0; i < coin.Length; i++)
            {
                Destroy(coin[i]);
            }
            //respawn all enemies
            SpawnPoopAndEnemies();

            //reset coins stats and display
            gameObject.GetComponent<CoinPickUp>().coin = 0;
            gameObject.GetComponent<CoinPickUp>().UpdateCoins();
        }
    }
    
    //spawn enemies 
    void SpawnPoopAndEnemies()
    {
        Instantiate(enemy, new Vector2(49f, -3.9f), Quaternion.identity);
        Instantiate(enemy, new Vector2(48.2f, 29.1f), Quaternion.identity);
        Instantiate(enemy, new Vector2(33.4f, 15.1f), Quaternion.identity);
        Instantiate(enemy, new Vector2(36.5f, 36.7f), Quaternion.identity);
        Instantiate(enemy, new Vector2(26.4f, 30.9f), Quaternion.identity);
        Instantiate(enemy, new Vector2(32.6f, 2.6f), Quaternion.identity);
        Instantiate(enemy, new Vector2(62.5f, 6.1f), Quaternion.identity);
        Instantiate(enemy, new Vector2(49.6f, 11.6f), Quaternion.identity);
        Instantiate(enemy, new Vector2(59.9f, 21.3f), Quaternion.identity);
        Instantiate(enemy, new Vector2(62.9f, 33.6f), Quaternion.identity);
        Instantiate(shooter, new Vector2(-123.3f, 3.7f), Quaternion.identity);
        Instantiate(shooter, new Vector2(-154f, -2f), Quaternion.identity);
        Instantiate(shooter, new Vector2(-143.1f, 37.4f), Quaternion.identity);
        Instantiate(shooter, new Vector2(-118f, 36.8f), Quaternion.identity);
        Instantiate(shooter, new Vector2(-118f, -13.5f), Quaternion.identity);
        Instantiate(strong, new Vector2(-144.2f, -11.5f), Quaternion.identity);
        Instantiate(strong, new Vector2(-127f, 20.4f), Quaternion.identity);
        Instantiate(strong, new Vector2(-147.8f, 7.1f), Quaternion.identity);
        Instantiate(strong, new Vector2(-141.3f, 20.4f), Quaternion.identity);
        Instantiate(strong, new Vector2(-152.1f, 27.4f), Quaternion.identity);

        Instantiate(poop, new Vector2(-3.27f, 5.64f), Quaternion.identity);
        Instantiate(poop, new Vector2(-19.31456f, 8.721005f), Quaternion.identity);
        Instantiate(poop, new Vector2(18.06818f, 8.824515f), Quaternion.identity);
        Instantiate(poop, new Vector2(16.10067f, 20.3141f), Quaternion.identity);
        Instantiate(poop, new Vector2(-20.86777f, 17.82993f), Quaternion.identity);
        Instantiate(poop, new Vector2(-3.885033f, 27.76693f), Quaternion.identity);
        Instantiate(poop, new Vector2(-18.38249f, -7.529885f), Quaternion.identity);
        Instantiate(poop, new Vector2(44.37119f, 21.6599f), Quaternion.identity);
        Instantiate(poop, new Vector2(46.33878f, 4.477282f), Quaternion.identity);
        //reset counter
        countText.text = "Geese Remaining: 10";
    }
    
    //Function to reduce player health
    public void TakeDamage(int damage) {
        //reduce current health as well as healthbar
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        //if player is no longer in level 2 then cancel invoke
        if(isLevel2 == false)
            CancelInvoke();
    }

    //function to invoke take 1 damage for when in snow
    public void InvokeTakeDamage() {
        if (isLevel2 && !wearingCoat)
        {
            //keep dealing damage as long as player is in snow level and not wearing a coat
            InvokeRepeating("TakeDamage", 1.0f, 0.8f);
        }
    }
    void TakeDamage()
    {
        //reduce current health as well as healthbar by 1
        TakeDamage(1);
    }
}
