using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class tienda : MonoBehaviour
{

    public GameObject particle;
    public inventory Dinero;
    public int valor;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if  (Input.GetKeyDown(KeyCode.G)) 
        {

            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }

    void venta(int price)
    {
        if ( Dinero.money >= price)
        {
            Dinero.money = Dinero.money - price;



        }

    }
}
