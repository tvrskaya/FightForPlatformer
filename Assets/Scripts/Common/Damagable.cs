using System;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    private static readonly int MinHealth = 0;

    [SerializeField] private int _health = 100;

    public event Action HealthEnded;

    public int Health => _health;

    public void TakeDamage(int amount)
    {
        if (_health <= MinHealth)
            return;

        _health -= amount;
        if (_health <= MinHealth)
        {
            _health = MinHealth;
            HealthEnded?.Invoke();
        }
    }
}
