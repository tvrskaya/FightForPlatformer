using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(HealthRenderer))]
public class Dummy : MonoBehaviour
{
    [SerializeField] private Damager _damager;

    private Health _health;
    private HealthRenderer _healthRenderer;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _healthRenderer = GetComponent<HealthRenderer>();

        _healthRenderer.Initialize(_health.MaxHealth);
    }

    private void OnEnable()
    {
        _health.HealthChanged += _healthRenderer.RenderHealth;
        _damager.DamageReceived += ProcessDamageReceived;
        _damager.HealReceived += ProcessHealReceived;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= _healthRenderer.RenderHealth;
        _damager.DamageReceived -= ProcessDamageReceived;
        _damager.HealReceived -= ProcessHealReceived;
    }

    private void ProcessDamageReceived(int amount)
    {
        _health.TakeDamage(amount);
    }

    private void ProcessHealReceived(int amount)
    {
        _health.Heal(amount);
    }
}
