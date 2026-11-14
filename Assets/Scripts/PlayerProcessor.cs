using UnityEngine;

public class PlayerProcessor : MonoBehaviour
{
    [SerializeField] private CoinDetector _coinDetector;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Mover _mover;
    [SerializeField] private InputProcessor _inputProcessor;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private EntityRotator _entityRotator;

    private void OnEnable()
    {
        _coinDetector.CoinTouched += ProcessCoinTouched;

        _inputProcessor.MovePressed += _mover.Move;
        _inputProcessor.JumpPressed += _mover.Jump;
        _inputProcessor.SprintPresssed += _mover.Sprint;

        _inputProcessor.JumpPressed += _playerAnimator.PlayJump;
        _inputProcessor.AttackPressed += _playerAnimator.PlayAttack;
    }
    
    private void OnDisable()
    {
        _coinDetector.CoinTouched -= ProcessCoinTouched;

        _inputProcessor.MovePressed -= _mover.Move;
        _inputProcessor.JumpPressed -= _mover.Jump;
        _inputProcessor.SprintPresssed -= _mover.Sprint;

        _inputProcessor.JumpPressed -= _playerAnimator.PlayJump;
        _inputProcessor.AttackPressed -= _playerAnimator.PlayAttack;
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
}
