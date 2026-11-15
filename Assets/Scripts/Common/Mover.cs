using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 5f;
    protected Rigidbody2D _rigidbody;

    public Vector2 Velocity => _rigidbody.linearVelocity;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;
    }

    public void Move(float direction)
    {
        _rigidbody.linearVelocity = new Vector2(direction * _moveSpeed, _rigidbody.linearVelocity.y);
    }
}
