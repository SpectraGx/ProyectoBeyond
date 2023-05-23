using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopTriggerCollider : MonoBehaviour
{
    public GameObject shopeee;
    [SerializeField] private shop uiShop;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger enter ");
        shopeee.SetActive(true);
        IShopCustomer shopCustomer = collision.GetComponent<IShopCustomer>();
        if (shopCustomer != null)
        {
            
            uiShop.Show(shopCustomer);
            Debug.Log("Show ui Shop");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger exit "); 
        shopeee.SetActive(false);
        IShopCustomer shopCustomer = collision.GetComponent<IShopCustomer>();
        if (shopCustomer != null)
        {
           
            uiShop.Hide();
            Debug.Log("Hide ui Shop");
        }
    }
}
