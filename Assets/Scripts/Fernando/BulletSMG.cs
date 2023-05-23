using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSMG : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float timelife;
    private Action<BulletSMG> disableaction;

    private void OnEnable()
    {
        StartCoroutine(TurnOffTime());
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            //Destroy(gameObject);
            disableaction(this);
        }
    }

    private IEnumerator TurnOffTime()
    {
        yield return new WaitForSeconds(timelife);
        disableaction(this);
    }

    public void DisableBulletSMG(Action<BulletSMG> disableactionparameter)
    {
        disableaction = disableactionparameter;
    }
}
