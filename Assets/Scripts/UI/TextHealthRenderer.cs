using TMPro;
using UnityEngine;

public class TextHealthRenderer : ValueRendererIface
{
    [SerializeField] private TMP_Text _label;

    private int _maxHealth;

    public override void Initialize(int maxValue)
    {
        _maxHealth = maxValue;
        RenderValue(maxValue);
    }

    public override void RenderValue(float newValue)
    {
        _label.text = $"{newValue}/{_maxHealth}";
    }
}
