using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private static readonly int MinHealth = 0;

    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _health = 100;

    public event Action HealthEnded;
    public event Action<float> HealthChanged;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _health;

    public void Heal(int amount)
    {
        if (_health <= MinHealth)
            return;

        _health = Mathf.Min(_health + amount, _maxHealth);

        HealthChanged?.Invoke(_health);
    }

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

        HealthChanged?.Invoke(_health);
    }
}
