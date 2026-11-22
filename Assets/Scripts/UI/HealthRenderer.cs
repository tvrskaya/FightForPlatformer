using UnityEngine;

public abstract class HealthRenderer : MonoBehaviour
{
    public abstract void Initialize(int maxValue);
    public abstract void RenderHealth(int newValue);
}
