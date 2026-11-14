using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private CoinDetector _coinDetector;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _coinSpawnTimer = 3f;

    private Coin[] _spawnedCoins;
    private Coroutine _coroutine;

    private void Awake()
    {
        _spawnedCoins = new Coin[_spawnPoints.Length];
    }

    private void OnEnable()
    {
        _coinDetector.CoinTouched += ProcessCoinTouched;
        _coroutine = StartCoroutine(SpawnCoinRoutine());
    }   

    private void OnDisable()
    {
        _coinDetector.CoinTouched -= ProcessCoinTouched;
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void ProcessCoinTouched(Coin coin)
    {
        int index = System.Array.IndexOf(_spawnedCoins, coin);

        if (index >= 0)
            _spawnedCoins[index] = null;

        Destroy(coin.gameObject);
    }

    private IEnumerator SpawnCoinRoutine()
    {
        var waitSeconds = new WaitForSeconds(_coinSpawnTimer);

        while (enabled)
        {
            SpawnCoins();
            yield return waitSeconds;
        }

        yield return null;
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _spawnPoints.Length; ++i)
        {
            if (_spawnedCoins[i] == null)
            {
                _spawnedCoins[i] = Instantiate(_coinPrefab, _spawnPoints[i]);
            }
        }
    }
}
