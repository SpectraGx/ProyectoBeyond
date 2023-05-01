using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float throwForce = 10f; // Fuerza de lanzamiento
    public float explosionRadius = 5f; // Radio de explosión
    public float explosionForce = 100f; // Fuerza de la explosión
    public GameObject explosionPrefab; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowGrenade();
        }
    }

    // Método para lanzar la granada
    void ThrowGrenade()
    {
        // Crear la granada como un objeto nuevo en la escena
        GameObject grenade = new GameObject("Grenade");
        grenade.transform.position = transform.position;
        Rigidbody2D rb = grenade.AddComponent<Rigidbody2D>();
        // Aplicar fuerza y torque a la granada para simular su lanzamiento
        Vector2 throwDirection = transform.up;
        rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-1f, 1f), ForceMode2D.Impulse);
        Destroy(grenade, 3f);
    }

    // Método para gestionar la explosión
    void Explode(Vector3 explosionPosition)
    {
        // Obtener todos los colliders dentro del radio de explosión
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPosition, explosionRadius);

        // Aplicar fuerza de explosión a los colliders con Rigidbody2D
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector3 explosionDirection = collider.transform.position - explosionPosition;
                rb.AddForce(explosionDirection.normalized * explosionForce, ForceMode2D.Impulse);
            }
        }

        // Instanciar el efecto de explosión
        Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);

        // Destruir la granada
        Destroy(gameObject);
    }

    // Método para dibujar el radio de explosión en el editor de Unity
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
