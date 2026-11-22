using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderHealthRenderer : HealthRenderer
{
    [SerializeField] private Slider _slider;
    [SerializeField, Min(0.01f)] private float _speed = 50f;

    private Coroutine _renderRoutine;
    private float _targetValue;

    public override void Initialize(int maxValue)
    {
        StopRendering();
        _slider.minValue = 0;
        _slider.maxValue = maxValue;
        _slider.SetValueWithoutNotify(maxValue);
    }

    public override void RenderHealth(int newValue)
    {
        StopRendering();
        _targetValue = Mathf.Clamp(newValue, _slider.minValue, _slider.maxValue);

        if (_slider.value != _targetValue)
            _renderRoutine = StartCoroutine(AnimateHealth(_targetValue));
    }

    private void OnDisable()
    {
        if (_renderRoutine == null)
            return;

        StopRendering();
        _slider.SetValueWithoutNotify(_targetValue);
    }

    private IEnumerator AnimateHealth(float targetValue)
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
