using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float moveSpeed;
    [SerializeField] public int attackDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;
    private Transform player;
    private bool canAttack = true;


    //          ANIMATOR            //
    private Animator animator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Movimiento",moveSpeed);
        animator.SetBool("Ataque",canAttack);
        MoveTowardsPlayer();

        if (IsInRange() && canAttack)
        {
            Attack();
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private bool IsInRange()
    {
        return Vector3.Distance(transform.position, player.position) <= attackRange;
    }

    private void Attack()
    {
        canAttack = false;

        // Obtener el componente PlayerController del jugador
        PlayerController playerController = player.GetComponent<PlayerController>();

        // Verificar si el jugador tiene el componente PlayerController
        if (playerController != null)
        {
            // Restarle vida al jugador
            playerController.TakeDamageEnemy(attackDamage);
        }

        StartCoroutine(ResetAttackCooldown());
    }

    private IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
