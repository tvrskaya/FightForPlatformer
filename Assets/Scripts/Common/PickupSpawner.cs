using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class PickupSpawner<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T _prefab;
    [SerializeField] private PickupDetector<T> _detector;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnTimer = 3f;

    private T[] _spawnedPickups;
    private Coroutine _coroutine;

    private void Awake()
    {
        _spawnedPickups = new T[_spawnPoints.Length];
    }

    private void OnEnable()
    {
        _detector.Touched += ProcessTouched;
        _coroutine = StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        _detector.Touched -= ProcessTouched;
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void ProcessTouched(T pickup)
    {
        int index = System.Array.IndexOf(_spawnedPickups, pickup);

        if (index >= 0)
            _spawnedPickups[index] = null;

        Destroy(pickup.gameObject);
    }

    private IEnumerator SpawnRoutine()
    {
        var waitSeconds = new WaitForSeconds(_spawnTimer);

        while (enabled)
        {
            Spawn();
            yield return waitSeconds;
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnPoints.Length; ++i)
        {
            if (_spawnedPickups[i] == null)
            {
                _spawnedPickups[i] = Instantiate(_prefab, _spawnPoints[i]);
            }
        }
    }
}
