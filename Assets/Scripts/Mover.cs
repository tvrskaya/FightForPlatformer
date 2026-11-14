using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private static readonly float BoundScaleX = 0.9f;
    private static readonly float BoundSizeY = 0.05f;

    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckDistance = 0.1f;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private float _sprintSpeedMultiplier = 1.5f;

    private bool _isGrounded = false;

    private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    public bool IsGrounded => _isGrounded;
    public Vector2 Velocity => _rigidbody.linearVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _rigidbody.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        Bounds bounds = _collider.bounds;
        Vector2 size = new Vector2(bounds.size.x * BoundScaleX, BoundSizeY);
        Vector2 origin = new Vector2(bounds.center.x, bounds.min.y);

        _isGrounded = Physics2D.BoxCast(origin, size, 0f, Vector2.down,
                                        _groundCheckDistance, _groundLayer);      
    }

    public void Move(float direction)
    {
        _rigidbody.linearVelocity = new Vector2(direction * _moveSpeed, _rigidbody.linearVelocity.y);
    }

    public void Jump()
    {
        if (_isGrounded)
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
    }

    public void Sprint(float direction)
    {
        _rigidbody.linearVelocity = new Vector2(direction * _moveSpeed * _sprintSpeedMultiplier, 
                                                _rigidbody.linearVelocity.y);
    }
}
