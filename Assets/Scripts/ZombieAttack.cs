using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How long the zombie waits after an attack to attack again")]
    private float delayBetweenAttacks = 1.5f;

    [SerializeField]
    [Tooltip("How far away the zombie can attack from")]
    private float maximumAttackRange = 1.5f;

    [SerializeField]
    private float delayBetweenAnimationAndDamage = 0.25f;

    private float attackTimer;

    private int damage = 1;
    private Health playerHealt;

    public event Action OnAttack = delegate { };

    private void Start()
    {
        playerHealt = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (CanAttack())
        {
            attackTimer = 0;
            Attack();
        }
    }

    private bool CanAttack()
    {
        return attackTimer >= delayBetweenAttacks &&
            Vector3.Distance(transform.position, playerHealt.transform.position) <= maximumAttackRange;

    }


    private void Attack()
    {
        OnAttack();

        StartCoroutine(DealDamageAfterDelay());  
    }

    IEnumerator DealDamageAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenAnimationAndDamage);
        playerHealt.Takehit(damage);
    }
}
