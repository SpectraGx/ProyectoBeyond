using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShoot : MonoBehaviour
{
    //          OBJECT POOLING          //
    [SerializeField] private Transform shootcontroller;
    [SerializeField] private Bullet bulletprefab;
    [SerializeField] private float timeshoots;
    private float nextshoottime;
    private ObjectPool<Bullet> bulletPool;

    //          MUNICION            //
    [SerializeField] private int maxAmmo = 12;
    private int actualAmmo = 12;
    private bool recargando = false;
    [SerializeField] private float reloadTime = 2.5f;

    //          ACTIVAR         //
    public bool pistola = false;

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
        if (recargando)
        {
            return;
        }
        if (actualAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }


        if (timeshoots > 0)
        {
            nextshoottime -= Time.deltaTime;
        }
        if (pistola == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (nextshoottime <= 0)
                {
                    Shoot();
                    nextshoottime = timeshoots;
                }
            }
        }
    }

    private IEnumerator Reload()
    {
        recargando = true;
        Debug.Log("Recargando");
        yield return new WaitForSeconds(reloadTime);

        actualAmmo = maxAmmo;
        recargando = false;
        Debug.Log("Recarga completa");
    }

    private void Shoot()
    {
        bulletPool.Get();
        actualAmmo--;
    }

    private void DisableBulletPool(Bullet bala)
    {
        bulletPool.Release(bala);
    }
}
