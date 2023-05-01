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
    }

    private void Shoot()
    {
        //Instantiate(bullet, shootcontroller.position, shootcontroller.rotation);
        bulletPool.Get();
    }

    private void DisableBulletPool(Bullet bala)
    {
        bulletPool.Release(bala);
    }
}
