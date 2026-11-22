using System;
using UnityEngine;
using UnityEngine.UI;

public class Damager : MonoBehaviour
{
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;

    [SerializeField] private int _damage = 10;
    [SerializeField] private int _heal = 10;

    public event Action<int> DamageReceived;
    public event Action<int> HealReceived;

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(ProcessDamagePressed);
        _healButton.onClick.AddListener(ProcessHealPressed);

    }

    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(ProcessDamagePressed);
        _healButton.onClick.RemoveListener(ProcessHealPressed);
    }

    private void ProcessDamagePressed()
    {
        DamageReceived?.Invoke(_damage);
    }
    
    private void ProcessHealPressed()
    {
        HealReceived?.Invoke(_heal);
    }
}
