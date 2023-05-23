using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
     [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float timelife;
    private Action<BulletShot> disableaction;

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

    public void DisableBulletShot(Action<BulletShot> disableactionparameter)
    {
        disableaction = disableactionparameter;
    }
}
