using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class PlayerAnimator : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int VelocityY = Animator.StringToHash("VelocityY");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Attack = Animator.StringToHash("Attack");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateMovement(Vector2 velocity, bool isGrounded)
    {
        _animator.SetFloat(Speed, Mathf.Abs(velocity.x));
        _animator.SetFloat(VelocityY, velocity.y);
        _animator.SetBool(IsGrounded, isGrounded);
    }

    public void PlayJump()
    {
        _animator.SetTrigger(Jump);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }
}
