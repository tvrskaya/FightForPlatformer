using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CoinDetector _coinDetector;
    [SerializeField] private AidKitDetector _aidKitDetector;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Health _health;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private EntityRotator _entityRotator;
    [SerializeField] private AttackProcessor _attackProcessor;
    [SerializeField] private ValueRendererIface _healthRenderer;
    [SerializeField] private ValueRendererIface _vampirismCooldownRenderer;
    [SerializeField] private Vampirism _vampirism;

    private void Awake()
    {
        _healthRenderer.Initialize(_health.MaxHealth);
    }

    private void OnEnable()
    {
        _coinDetector.Touched += ProcessCoinTouched;
        _aidKitDetector.Touched += ProcessAidKitTouched;

        _inputReader.MovePressed += _mover.Move;
        _inputReader.JumpPressed += _mover.Jump;
        _inputReader.SprintPresssed += _mover.Sprint;

        _inputReader.JumpPressed += _playerAnimator.PlayJump;
        _inputReader.AttackPressed += _attackProcessor.Attack;
        _attackProcessor.AttackRequested += _playerAnimator.PlayAttack;
        _health.HealthChanged += _healthRenderer.RenderValue;

        _inputReader.VampirismPressed += _vampirism.StartVampirism;
        _vampirism.CooldownChanged += _vampirismCooldownRenderer.RenderValue;

        _healthRenderer.Initialize(_health.MaxHealth);
    }
    
    private void OnDisable()
    {
        _coinDetector.Touched -= ProcessCoinTouched;
        _aidKitDetector.Touched -= ProcessAidKitTouched;

        _inputReader.MovePressed -= _mover.Move;
        _inputReader.JumpPressed -= _mover.Jump;
        _inputReader.SprintPresssed -= _mover.Sprint;

        _inputReader.JumpPressed -= _playerAnimator.PlayJump;
        _inputReader.AttackPressed -= _attackProcessor.Attack;
        _attackProcessor.AttackRequested -= _playerAnimator.PlayAttack;
        _health.HealthChanged -= _healthRenderer.RenderValue;
        _vampirism.CooldownChanged -= _vampirismCooldownRenderer.RenderValue;

        _inputReader.VampirismPressed -= _vampirism.StartVampirism;
    }

    private void Update()
    {
        _playerAnimator.UpdateMovement(_mover.Velocity, _mover.IsGrounded);
        _entityRotator.UpdateEntityRotation(_mover.Velocity);
    }

    private void ProcessCoinTouched(Coin coin)
    {
        _wallet.AddCoins(coin.Value);
    }

    private void ProcessAidKitTouched(AidKit aidKit)
    {
        _health.Heal(aidKit.HealAmount);
    }
}
