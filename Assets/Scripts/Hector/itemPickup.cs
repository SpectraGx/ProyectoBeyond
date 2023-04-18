using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class itemPickup : MonoBehaviour
{

    [SerializeField]
    private GameObject pickUpText;
    private inventory Inventory;
    private GameObject pruebasVar;
    public GameObject itemButton;
    private bool pickUpAllowed;
    int numero = 0;

    // Use this for initialization
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);

        Inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
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

   public void pruebaScore()
    {
        numero = numero + 1;
        pruebasVar.GetComponent<UnityEngine.UI.Text>().text = "Score : " + numero;
    }

}

