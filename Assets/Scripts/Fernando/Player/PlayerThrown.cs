using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerThrown : MonoBehaviour
{
    /* Los comentarios son variables y metodos que son eliminados con la implementación del Object Pooling

    [SerializeField] private Transform throwncontroller;
    //[SerializeField] private GameObject Grenade;
    [SerializeField] private Grenade grenadeprefab;
    [SerializeField] private float timelaunch;
    private float nextlaunchtime;
    private ObjectPool<Grenade> GrenadePool;

    private void Start()
    {
        GrenadePool = new ObjectPool<Grenade>(() =>
        {
            Grenade granada = Instantiate(grenadeprefab, throwncontroller.position, throwncontroller.rotation);
            granada.DisableGrenade(DisableGrenadePool);
            return granada;
        }, granada =>
        {
            granada.transform.position = throwncontroller.position;
            granada.transform.rotation = throwncontroller.rotation;
            granada.gameObject.SetActive(true);
        }, granada =>
        {
            granada.gameObject.SetActive(false);
        }, granada =>
        {
            Destroy(granada.gameObject);
        }, true, 10, 25);
    }

    private void Update()
    {
        if (timelaunch > 0)
        {
            nextlaunchtime -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (nextlaunchtime <= 0)
            {
                Shoot();
                nextlaunchtime = timelaunch;
            }
        }
    }

    private void Shoot()
    {
        //Instantiate(Grenade, throwncontroller.position, throwncontroller.rotation);
        GrenadePool.Get();
    }

    private void DisableGrenadePool(Grenade granada)
    {
        GrenadePool.Release(granada);
    }
    */
}
