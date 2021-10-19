using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Creating instance variables
    public Transform firePoint; // get the position of the firepoint where the bullet will come out  of the player
    public GameObject player;
    public float cooldown= 1f; // cooldown for how often player can shoot weapon
    
    public float weaponForce = 20f;

    private float _timeRemaining;

    public void Start()
    {
        //Setting the instance variable to 0
        _timeRemaining = 0;
    }
    // Update is called once per frame
    public virtual void Update()
    {
        //If the instance variable is less than or equal to zero
        if (_timeRemaining <= 0)
        {
            //if user clicks on the Fire1 button then call shoot()
            if (Input.GetButtonDown("Fire1"))
            {
                //This will trigger the shoot method
                Shoot();
                //This will set the instance variable timeRemaining equal to cooldown to add a cooldown onto shooting the gun
                _timeRemaining = cooldown;
            }
            
        }
        else
            _timeRemaining -= Time.deltaTime;
    }
    public virtual void Shoot()
    {
    }
}
