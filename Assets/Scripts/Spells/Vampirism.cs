using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    private static readonly float ResetedCooldown = 0f;
    private static readonly int CooldownScale = 100;

    [SerializeField] private int _duration = 6;
    [SerializeField] private int _cooldown = 4;
    [SerializeField] private float _radius = 4f;
    [SerializeField] private float _vampirismStep = 0.2f;
    [SerializeField] private float _cooldownStep = 0.5f;
    [SerializeField] private int _vampiricPower = 3;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private LayerMask _layerMask;
    
    private EntityDetector _detector;
    private bool _isReady = true;

    public event Action<float> CooldownChanged;

    private void Awake()
    {
        _detector = GetComponent<EntityDetector>();
    }

    public void StartVampirism()
    {
        if (_isReady == false)
        {
            return;
        }

        _isReady = false;
        StartCoroutine(VampirismSequenceRoutine());
    }

    private IEnumerator VampirismSequenceRoutine()
    {
        yield return StartCoroutine(VampirismRoutine());
        yield return StartCoroutine(CooldownRoutine());

        _isReady = true;
    }

    private IEnumerator VampirismRoutine()
    {
        var wait = new WaitForSeconds(_vampirismStep);

        float elapsed = 0f;

        while (elapsed < _duration)
        {
            var enemy = _detector.GetNearest(_layerMask, _radius);

            if (enemy != null)
            {
                enemy.GetComponent<Health>().TakeDamage(_vampiricPower);
                _playerHealth.Heal(_vampiricPower);
            }


            yield return wait;
            elapsed += _vampirismStep;

            CooldownChanged?.Invoke(CooldownScale - elapsed / _duration * CooldownScale);
        }
    }

    private IEnumerator CooldownRoutine()
    {
        var wait = new WaitForSeconds(_cooldownStep);

        float elapsed = ResetedCooldown;

        while (elapsed < _cooldown)
        {
            yield return wait;

            elapsed += _cooldownStep;

            CooldownChanged?.Invoke(elapsed / _cooldown * CooldownScale);
        }

        yield return null;
    }
}
