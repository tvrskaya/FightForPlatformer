using TMPro;
using UnityEngine;

public class TextHealthRenderer : HealthRenderer
{
    [SerializeField] private TMP_Text _label;

    private int _maxHealth;

    public override void Initialize(int maxValue)
    {
        _maxHealth = maxValue;
        RenderHealth(maxValue);
    }

    public override void RenderHealth(int newValue)
    {
        _label.text = $"{newValue}/{_maxHealth}";
    }
}
