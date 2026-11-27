using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coinsAmount;

    public int CoinsAmount => _coinsAmount;

    public void AddCoins(int value)
    {
        _coinsAmount += value;
    }
}
