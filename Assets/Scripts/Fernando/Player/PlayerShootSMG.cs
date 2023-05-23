using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShootSMG : MonoBehaviour
{
    //          OBJECT POOLING          //
    [SerializeField] private Transform shootcontroller;
    [SerializeField] private BulletSMG bulletSMGSMGprefab;
    [SerializeField] private float timeshoots;
    private float nextshoottime;
    private ObjectPool<BulletSMG> bulletSMGPool;

    //          MUNICION            //
    [SerializeField] private int maxAmmo = 20;
    private int actualAmmo = 20;
    private bool recargando = false;
    [SerializeField] private float reloadTime = 7.5f;

    //          ACTIVAR         //
    public bool smg = false;

    //          ACTIVAR POR TECLADO         //
    public bool num4 = false;

    private void Start()
    {
        bulletSMGPool = new ObjectPool<BulletSMG>(() =>
        {
            BulletSMG bala = Instantiate(bulletSMGSMGprefab, shootcontroller.position, shootcontroller.rotation);
            bala.DisableBulletSMG(DisableBulletSMGPool);
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

        if (num4 == true)
        {
            if (smg == true)
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
        bulletSMGPool.Get();
        actualAmmo--;
    }

    private void DisableBulletSMGPool(BulletSMG bala)
    {
        bulletSMGPool.Release(bala);
    }
}
