using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class PlayerAnimator : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int VelocityY = Animator.StringToHash("VelocityY");
    private static readonly int Jump = Animator.StringToHash("Jump");

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateMovement(Vector2 velocity, bool isGrounded)
    {
        _animator.SetFloat(Speed, Mathf.Abs(velocity.x));
        _animator.SetFloat(VelocityY, velocity.y);
        _animator.SetBool(IsGrounded, isGrounded);

        if (velocity.x != 0f)
            _spriteRenderer.flipX = velocity.x < 0f;
    }

    public void PlayJump()
    {
        _animator.SetTrigger(Jump);
    }
}
