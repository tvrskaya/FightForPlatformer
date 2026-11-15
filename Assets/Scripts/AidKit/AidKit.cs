using UnityEngine;

public class AidKit : MonoBehaviour
{
    [SerializeField, Min(0)] private int _healAmount = 25;

    public int HealAmount => _healAmount;
}
