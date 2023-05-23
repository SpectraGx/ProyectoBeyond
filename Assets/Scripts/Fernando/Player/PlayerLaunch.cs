using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerLaunch : MonoBehaviour
{
    public Grenade grenadeprefab;
    public Transform launchOffSet;
    public bool grenade = false;
    [SerializeField] private int maxAmmo = 1;
    public int actualAmmo = 0;

    //          ACTIVAR POR TECLADO         //
    public bool num5 = false;


    private void Update()
    {
        if (actualAmmo == maxAmmo)
        {
            if (num5 == true)
            {
                if (grenade == true)
                {
                    if (Input.GetButtonDown("Fire2"))
                    {
                        Instantiate(grenadeprefab, launchOffSet.position, transform.rotation);
                        actualAmmo--;
                    }
                }
            }
        }
    }
}
