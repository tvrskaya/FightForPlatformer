using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField, Min(0)] private float _attackRadius = 1f;
    [SerializeField, Min(0)] private int _damage = 10;
    [SerializeField] private LayerMask _damagableLayers;

    public void DealDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            _attackPoint.position, _attackRadius, _damagableLayers);

        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent(out Damagable target))
                target.TakeDamage(_damage);
        }
    }
}
