using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //Creating instance variables
    public GameObject shopBox;
    public Sprite green;
    public Sprite blue;
    public Sprite red;
    public Sprite coat;
    public GameObject player;
    public bool enterShop;
    public bool boughtMine = false;
    public bool boughtCoat = false;

    // Update is called once per frame
    void Update()
    {
        //This will make it so when the user presses the 'x' key it will pop up a GUI to display the shop
        if (Input.GetKeyDown(KeyCode.X) && enterShop)
        {
            //When the user presses the 'x' key when the shop is open, this will close the shop GUI
            if (shopBox.activeInHierarchy)
            {
                shopBox.SetActive(false);
            }
            //This will be when the shop GUI isn't open, it will open the GUI once 'x' is pressed on the shop
            else
            {
                shopBox.SetActive(true);
            }
        }
    }

    //This is a method to equip the mine when the user is purchasing it from the shop
    public void EquipMine()
    {
        //When the user selects the mine to purchase from the shop
        if (boughtMine == true)
        {
            //Changing the components for the user
            player.GetComponent<SpriteRenderer>().sprite = red;
            player.GetComponent<PlayerMovement>().whichWeapon = 1;
            player.GetComponent<PlayerHealth>().wearingCoat = false;
        }
        //This will be if the user buys the mine with above 50 coins (requirement to purchase the mine)
        else if ((boughtMine == false) && (player.GetComponent<CoinPickUp>().coin >= 50))
        {
            player.GetComponent<CoinPickUp>().coin -= 50;
            player.GetComponent<CoinPickUp>().UpdateCoins();
            player.GetComponent<SpriteRenderer>().sprite = red;
            player.GetComponent<PlayerMovement>().whichWeapon = 1;
            boughtMine = true;
            player.GetComponent<PlayerHealth>().wearingCoat = false;
        }
        else
        {

        }
    }
    //Method to set the winter for level 2
    public void SetWinter()
    {
        //Make sure player doesn't rebuy the coat
        if (boughtCoat == true)
        {
            player.GetComponent<SpriteRenderer>().sprite = coat;
            player.GetComponent<PlayerMovement>().whichWeapon = 0;
            player.GetComponent<PlayerHealth>().wearingCoat = true;
        }
        else if ((boughtCoat == false) && (player.GetComponent<CoinPickUp>().coin >= 50))
        {
            player.GetComponent<CoinPickUp>().coin -= 50;
            player.GetComponent<CoinPickUp>().UpdateCoins();
            player.GetComponent<SpriteRenderer>().sprite = coat;
            player.GetComponent<PlayerMovement>().whichWeapon = 0;
            boughtCoat = true;
            player.GetComponent<PlayerHealth>().wearingCoat = true;
        }
        else
        {

        }

    }

    //Function for green skin
    public void SetGreen()
    {
        player.GetComponent<SpriteRenderer>().sprite = green;
        player.GetComponent<PlayerMovement>().whichWeapon = 0;
        player.GetComponent<PlayerHealth>().wearingCoat = false;
    }

    //Function for blue skin
    public void SetBlue()
    {
        player.GetComponent<SpriteRenderer>().sprite = blue;
        player.GetComponent<PlayerMovement>().whichWeapon = 0;
        player.GetComponent<PlayerHealth>().wearingCoat = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if player is near shop
        if (collision.CompareTag("Player"))
        {
            enterShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //check if player left shop
        if (collision.CompareTag("Player"))
        {
            enterShop = false;
            shopBox.SetActive(false);
        }
    }
}
