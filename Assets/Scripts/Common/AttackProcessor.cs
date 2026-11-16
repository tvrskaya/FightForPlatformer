using System;
using UnityEngine;

public class AttackProcessor : MonoBehaviour
{
    [SerializeField, Min(0f)]
    private float attackCooldown = 0.5f;

    private float nextAttackTime;

    public event Action AttackRequested;

    public void Attack()
    {
        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + attackCooldown;
        AttackRequested?.Invoke();
    }
}