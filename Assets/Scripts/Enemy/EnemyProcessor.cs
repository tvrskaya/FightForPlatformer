using UnityEngine;

[RequireComponent(typeof(Mover), typeof(EnemyPatrol), typeof(PlayerDetector))]
[RequireComponent(typeof(AttackProcessor))]
[RequireComponent(typeof(Health))]
public class EnemyProcessor : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _distanceToAttack = 5f;
    [SerializeField] private EntityRotator _entityRotator;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private HealthRenderer _healthRenderer;

    private Health _health;
    private EnemyPatrol _patrol;
    private PlayerDetector _detector;
    private Mover _mover;
    private AttackProcessor _attackProcessor;

    private void Awake()
    {
        _health = GetComponent<Health>();
        if (_entityRotator == null)
            _entityRotator = GetComponent<EntityRotator>();

        if (_animator == null)
            _animator = GetComponent<EnemyAnimator>();

        _patrol = GetComponent<EnemyPatrol>();
        _detector = GetComponent<PlayerDetector>();
        _mover = GetComponent<Mover>();
        _attackProcessor = GetComponent<AttackProcessor>();

        _healthRenderer.Initialize(_health.MaxHealth);
    }

    private void OnEnable()
    {
        _health.HealthEnded += ProcessDeath;
        _attackProcessor.AttackRequested += _animator.PlayAttack;
        _health.HealthChanged += _healthRenderer.RenderHealth;
    }

    private void OnDisable()
    {
        _health.HealthEnded -= ProcessDeath;
        _attackProcessor.AttackRequested -= _animator.PlayAttack;
        _health.HealthChanged -= _healthRenderer.RenderHealth;
    }

    private void FixedUpdate()
    {
        if (_detector.IsPlayerDetected(out float direction, out float distance))
        {
            _entityRotator.UpdateEntityRotation(new Vector2(direction, 0f));

            if (Mathf.Abs(distance) <= _distanceToAttack)
            {
                _mover.Move(0f);
                _attackProcessor.Attack();
            }
            else
            {
                _mover.Move(direction);
            }
        }
        else
        {
            float patrolDirection = _patrol.GetCurrentDirection();

            _mover.Move(patrolDirection);
            _entityRotator.UpdateEntityRotation(new Vector2(patrolDirection, 0f));
        }
    }

    private void ProcessDeath()
    {
        Destroy(gameObject);
    }
}
