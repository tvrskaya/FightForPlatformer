using UnityEngine;
using UnityEngine.UI;

public class SliderRenderer : ValueRendererIface
{
    [SerializeField] private Slider _slider;

    public override void Initialize(int maxValue)
    {
        _slider.maxValue = maxValue;
        RenderValue(maxValue);
    }

    public override void RenderValue(float newValue)
    {
        _slider.SetValueWithoutNotify(newValue);
    }
}
