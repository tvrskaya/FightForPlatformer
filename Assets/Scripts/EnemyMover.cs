using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _reachDistance = 0.1f;

    private Rigidbody2D _rigidbody;
    private Transform _currentTarget;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;
        _currentTarget = _rightPoint;
    }

    private void Update()
    {
        float distance = _currentTarget.position.x - transform.position.x;

        if (Mathf.Abs(distance) < _reachDistance)
            _currentTarget = _currentTarget == _leftPoint ? _rightPoint : _leftPoint;

        float direction = Mathf.Sign(distance);
        _rigidbody.linearVelocity = new Vector2(direction * _speed, _rigidbody.linearVelocity.y);
    }
}
