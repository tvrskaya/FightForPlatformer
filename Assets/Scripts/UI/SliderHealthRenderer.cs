using UnityEngine;
using UnityEngine.UI;

public class SliderHealthRenderer : HealthRenderer
{
    [SerializeField] private Slider _slider;

    public override void Initialize(int maxValue)
    {
        _slider.maxValue = maxValue;
        RenderHealth(maxValue);
    }

    public override void RenderHealth(int newValue)
    {
        _slider.SetValueWithoutNotify(newValue);
    }
}
