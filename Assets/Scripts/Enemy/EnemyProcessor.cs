using UnityEngine;

[RequireComponent(typeof(Mover), typeof(EnemyPatrol), typeof(PlayerDetector))]
[RequireComponent(typeof(AttackProcessor), typeof(EnemyAnimator), typeof(EntityRotator))]
[RequireComponent(typeof(Health))]
public class EnemyProcessor : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _distanceToAttack = 5f;

    private Health _health;
    private EntityRotator _entityRotator;
    private EnemyPatrol _patrol;
    private PlayerDetector _detector;
    private Mover _mover;
    private EnemyAnimator _animator;
    private AttackProcessor _attackProcessor;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _entityRotator = GetComponent<EntityRotator>();
        _patrol = GetComponent<EnemyPatrol>();
        _detector = GetComponent<PlayerDetector>();
        _mover = GetComponent<Mover>();
        _animator = GetComponent<EnemyAnimator>();
        _attackProcessor = GetComponent<AttackProcessor>();
    }

    private void OnEnable()
    {
        _health.HealthEnded += ProcessDeath;
        _attackProcessor.AttackRequested += _animator.PlayAttack;
    }

    private void OnDisable()
    {
        _health.HealthEnded -= ProcessDeath;
        _attackProcessor.AttackRequested -= _animator.PlayAttack;
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