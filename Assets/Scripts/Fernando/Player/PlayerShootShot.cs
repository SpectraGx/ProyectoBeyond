using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShootShot : MonoBehaviour
{
    //          OBJECT POOLING          //
    [SerializeField] private Transform shootcontroller;
    [SerializeField] private BulletShot bulletShotShootprefab;
    [SerializeField] private float timeshoots;
    private float nextshoottime;
    private ObjectPool<BulletShot> bulletShotPool;

    //          MUNICION            //
    [SerializeField] private int maxAmmo = 8;
    private int actualAmmo = 8;
    private bool recargando = false;
    [SerializeField] private float reloadTime = 4f;

    //          ACTIVAR         //
    public bool escopeta = false;

    //          ACTIVAR POR TECLADO         //
    public bool num2 = false;

    private void Start()
    {
        bulletShotPool = new ObjectPool<BulletShot>(() =>
        {
            BulletShot bala = Instantiate(bulletShotShootprefab, shootcontroller.position, shootcontroller.rotation);
            bala.DisableBulletShot(DisableBulletShotPool);
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

        if (num2 == true)
        {
            if (escopeta == true)
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
        bulletShotPool.Get();
        actualAmmo--;
    }

    private void DisableBulletShotPool(BulletShot bala)
    {
        bulletShotPool.Release(bala);
    }
}
