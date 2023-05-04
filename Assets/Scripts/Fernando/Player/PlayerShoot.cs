using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShoot : MonoBehaviour
{
    /* Los comentarios son variables y metodos que son eliminados con la implementación del Object Pooling*/

    [SerializeField] private Transform shootcontroller;
    //[SerializeField] private GameObject bullet;
    [SerializeField] private Bullet bulletprefab;
    [SerializeField] private float timeshoots;
    private float nextshoottime;
    private ObjectPool<Bullet> bulletPool;



    //          GRANADA         //
    /*
    [SerializeField] private Transform throwncontroller;
    //[SerializeField] private GameObject Grenade;
    [SerializeField] private Grenade grenadeprefab;
    [SerializeField] private float timelaunch;
    private float nextlaunchtime;
    private ObjectPool<Grenade> grenadePool;
    */

    private void Start()
    {
        bulletPool = new ObjectPool<Bullet>(() =>
        {
            Bullet bala = Instantiate(bulletprefab, shootcontroller.position, shootcontroller.rotation);
            bala.DisableBullet(DisableBulletPool);
            return bala;
        }, bala =>
        {
            bala.transform.position = shootcontroller.position;
            bala.transform.rotation = shootcontroller.rotation;
            bala.gameObject.SetActive(true);
        }, bala =>
        {
            bala.gameObject.SetActive(false);
        }, bala =>
        {
            Destroy(bala.gameObject);
        }, true, 10, 25);


        //          GRANADA         //
        /*
        grenadePool = new ObjectPool<Grenade>(() =>
        {
            Grenade granada = Instantiate(grenadeprefab, throwncontroller.position, throwncontroller.rotation);
            granada.DisableGrenade(DisablegrenadePool);
            return granada;
        }, granada =>
        {
            granada.transform.position = throwncontroller.position;
            //granada.transform.rotation = throwncontroller.rotation;
            granada.gameObject.SetActive(true);
        }, granada =>
        {
            granada.gameObject.SetActive(false);
        }, granada =>
        {
            Destroy(granada.gameObject);
        }, true, 10, 25);
        */
    }

    private void Update()
    {
        if (timeshoots > 0)
        {
            nextshoottime -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (nextshoottime <= 0)
            {
                Shoot();
                nextshoottime = timeshoots;
            }
        }


        //          LANZAMIENTO DE GRANADA          //
        /*
        if (timelaunch > 0)
        {
            nextlaunchtime -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (nextlaunchtime <= 0)
            {
                Launch();
                nextlaunchtime = timelaunch;
            }
        }
        */
    }

    private void Shoot()
    {
        //Instantiate(bullet, shootcontroller.position, shootcontroller.rotation);
        bulletPool.Get();
    }

    /*
    private void Launch(){
        grenadePool.Get();
    }
    */

    private void DisableBulletPool(Bullet bala)
    {
        bulletPool.Release(bala);
    }


    //          DESACTIVAR POOL DE GRANADA          //
    /*
    private void DisablegrenadePool(Grenade granada)
    {
        grenadePool.Release(granada);
    }
    */
}
