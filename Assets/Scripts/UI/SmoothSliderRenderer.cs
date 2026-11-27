using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderRenderer : ValueRendererIface
{
    private static readonly int InitialMaxValue = 100;

    [SerializeField] private Slider _slider;
    [SerializeField, Min(0.01f)] private float _speed = 50f;

    private Coroutine _renderRoutine;
    private float _targetValue;

    private void Awake()
    {
        _slider.maxValue = InitialMaxValue;
        _slider.SetValueWithoutNotify(_slider.maxValue);
    }
    
    private void OnDisable()
    {
        if (_renderRoutine == null)
            return;

        StopRendering();
        _slider.SetValueWithoutNotify(_targetValue);
    }

    public override void Initialize(int maxValue)
    {
        StopRendering();
        _slider.minValue = 0;
        _slider.maxValue = maxValue;
        _slider.SetValueWithoutNotify(maxValue);
    }

    public override void RenderValue(float newValue)
    {
        StopRendering();
        _targetValue = Mathf.Clamp(newValue, _slider.minValue, _slider.maxValue);

        if (_slider.value != _targetValue)
            _renderRoutine = StartCoroutine(AnimateValueChanging(_targetValue));
    }

    public void Reset()
    {
        _slider.SetValueWithoutNotify(_slider.minValue);
    }

    private IEnumerator AnimateValueChanging(float targetValue)
    {
        float currentValue = _slider.value;

        while (currentValue != targetValue)
        {
            yield return null;
            currentValue = Mathf.MoveTowards(currentValue, targetValue, _speed * Time.deltaTime);
            _slider.SetValueWithoutNotify(currentValue);
        }

        _renderRoutine = null;
    }

    private void StopRendering()
    {
        if (_renderRoutine == null)
            return;

        StopCoroutine(_renderRoutine);
        _renderRoutine = null;
    }
}
