using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemy : PlayerFollowerEnemy
{


    public override void setScore()
    {
        //update counter based on the number of Enemies left
        int strongGeese = GameObject.FindGameObjectsWithTag("StrongEnemy").Length -1;
        int shootingEnemy = GameObject.FindGameObjectsWithTag("ShootingEnemy").Length;


        if (strongGeese + shootingEnemy <= 0)
        {
            countText.text = "You Beat The Game!";

        }
        else
            countText.text = "Strong Geese Remaining: " + strongGeese.ToString() + "\nShooting Enemy Remaining: " + shootingEnemy.ToString();
    }
}
