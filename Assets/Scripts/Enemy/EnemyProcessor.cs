using UnityEngine;

public class EnemyProcessor : MonoBehaviour
{
    private Damagable _damagable;
    private EntityRotator _entityRotator;
    private EnemyPatrol _patrol;
    private PlayerDetector _detector;
    private Mover _mover;

    private void Awake()
    {
        _damagable = GetComponent<Damagable>();
        _entityRotator = GetComponent<EntityRotator>();
        _mover = GetComponent<Mover>();
        _patrol = GetComponent<EnemyPatrol>();
        _detector = GetComponent<PlayerDetector>();
    }

    private void OnEnable()
    {
        _damagable.HealthEnded += ProcessDeath;
    }

    private void OnDisable()
    {
        _damagable.HealthEnded -= ProcessDeath;
    }

    private void Update()
    {
        float moveDirection = _patrol.GetCurrentDirection();

        if (_detector.IsPlayerDetected(out float direction))
            moveDirection = direction;
        
        _mover.Move(moveDirection);

        _entityRotator.UpdateEntityRotation(_mover.Velocity);
    }

    private void ProcessDeath()
    {
        Destroy(gameObject);
    }
}
