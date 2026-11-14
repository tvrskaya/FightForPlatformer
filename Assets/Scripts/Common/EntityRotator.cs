using UnityEngine;

public class EntityRotator : MonoBehaviour
{
    private static readonly Quaternion LeftRotation = Quaternion.Euler(0, 0, 0);
    private static readonly Quaternion RightRotation = Quaternion.Euler(0, 180, 0);

    private static readonly float WatchLeftValue = 0f;

    public void UpdateEntityRotation(Vector2 velocity)
    {
        if (velocity.x > WatchLeftValue)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (velocity.x < WatchLeftValue)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
