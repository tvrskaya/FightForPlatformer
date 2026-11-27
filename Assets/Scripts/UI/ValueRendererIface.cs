using UnityEngine;

public abstract class ValueRendererIface : MonoBehaviour
{
    public abstract void Initialize(int maxValue);
    public abstract void RenderValue(float newValue);
}
