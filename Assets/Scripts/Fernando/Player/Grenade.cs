using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grenade : MonoBehaviour
{
    public bool thrown;
    public Vector3 launchoffset;
    public float speed;
    public float damage;
    public float splashrange;
    //public float timelife;
    //private Action<Grenade> disableaction;


    void Start()
    {
        if (thrown)
        {
            var direction = transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        }
        transform.Translate(launchoffset);

        Destroy(gameObject, 2);
    }

    void Update()
    {
        if (!thrown)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (splashrange > 0)
        {
            var hitcolliders = Physics2D.OverlapCircleAll(transform.position, splashrange);
            foreach (var hitcollider in hitcolliders)
            {
                var enemy = hitcollider.GetComponent<Enemy>();
                if (enemy)
                {
                    var closetPoint = hitcollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closetPoint, transform.position);

                    var damagePercent = Mathf.InverseLerp(splashrange, 0, distance);
                    enemy.TakeDamage(damagePercent * damage);
                }
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.collider.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
            //disableaction(this);
        }
    }

    /*
    public void DisableGrenade(Action<Grenade> disableactionparameterG)
    {
        disableaction = disableactionparameterG;
    }

    private void OnEnable()
    {
        //Destroy(gameObject,timelife);
        StartCoroutine(TurnOffTime());
    }*/


    /*private IEnumerator TurnOffTime()
    {
        yield return new WaitForSeconds(timelife);
        disableaction(this);
    }*/
}
