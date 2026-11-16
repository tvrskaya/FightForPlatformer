using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class EnemyAnimator : MonoBehaviour
{
    private static readonly int Attack = Animator.StringToHash("Attack");
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        Debug.Log("PLAY ATTACK");
        _animator.SetTrigger(Attack);
    }
}
