using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerLaunch : MonoBehaviour
{
    public Grenade grenadeprefab;
    public Transform launchOffSet;
    public bool grenade = false;


    private void Update()
    {
        if (grenade == true)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Instantiate(grenadeprefab, launchOffSet.position, transform.rotation);
            }
        }
    }
}
