using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShootAR : MonoBehaviour
{
    //          OBJECT POOLING          //
    [SerializeField] private Transform shootcontroller;
    [SerializeField] private BulletAR bulletARprefab;
    [SerializeField] private float timeshoots;
    private float nextshoottime;
    private ObjectPool<BulletAR> bulletARPool;

    //          MUNICION            //
    [SerializeField] private int maxAmmo = 30;
    private int actualAmmo = 30;
    private bool recargando = false;
    [SerializeField] private float reloadTime = 10f;

    //          ACTIVAR         //
    public bool ar = false;

    //          ACTIVAR POR TECLADO         //
    public bool num3 = false;

    private void Start()
    {
        bulletARPool = new ObjectPool<BulletAR>(() =>
        {
            BulletAR bala = Instantiate(bulletARprefab, shootcontroller.position, shootcontroller.rotation);
            bala.DisableBulletAR(DisableBulletARPool);
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

        if (num3 == true)
        {
            if (ar == true)
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
        bulletARPool.Get();
        actualAmmo--;
    }

    private void DisableBulletARPool(BulletAR bala)
    {
        bulletARPool.Release(bala);
    }
}
