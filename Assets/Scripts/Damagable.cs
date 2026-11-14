using UnityEngine;

public class Damagable : MonoBehaviour
{
    private static readonly int MinHealth = 0;

    [SerializeField] private int _health = 100;

    public int Health => _health;

    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health < MinHealth)
            _health = MinHealth;
    }
}
