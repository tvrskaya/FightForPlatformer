using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class PickupDetector<T> : MonoBehaviour where T : Component
{
    public event Action<T> Touched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out T pickup))
        {
            Touched?.Invoke(pickup);
        }
    }
}
