using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float explosiveForce;

    public void Explosion(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,radius);

        foreach (Collider2D collisionador in objects){
            Rigidbody2D rb = collisionador.GetComponent<Rigidbody2D>();
            if (rb!=null){
                Vector2 direction = collisionador.transform.position - transform.position;
                float distance = 1+direction.magnitude;
                float finalForce = explosiveForce/distance;
                rb.AddForce(direction*finalForce);
            }

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")){
            Debug.Log ("El jugador ha activado la bomba");
            Explosion();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
}
