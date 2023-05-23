using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePickup : MonoBehaviour
{
    [SerializeField]
    private GameObject pickUpText;
    private InventoryWeapon Inventory;
    private GameObject pruebasVar;
    public GameObject itemButton;
    private bool pickUpAllowed;
    //int numero = 0;

    //          REFERENCIAS CLASES          //
    private PlayerLaunch playerLaunch;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryWeapon>();
        
        playerLaunch = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLaunch>();
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
            playerLaunch.actualAmmo++;
            playerLaunch.grenade = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("PJ"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("PJ"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        for (int i = 0; i < Inventory.slots.Length; i++)
        {
            if (Inventory.isFull[i] == false)
            {
                //se puede recoger y asi xd
                Instantiate(itemButton, Inventory.slots[i].transform, false);
                Inventory.isFull[i] = true;
                Destroy(gameObject);
                break;
            }
        }
    }
}
