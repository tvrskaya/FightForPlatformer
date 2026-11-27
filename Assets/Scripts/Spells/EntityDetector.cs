using UnityEngine;

public class EntityDetector : MonoBehaviour
{
    public Transform GetNearest(LayerMask layerMask, float radius)
    {
        Collider2D[] entities = Physics2D.OverlapCircleAll(
                        transform.position, radius, layerMask);

        Transform nearestEntity = null;
        float minDistance = Mathf.Infinity;

        foreach (Collider2D entity in entities)
        {
            float distance = (entity.transform.position - transform.position).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEntity = entity.transform;
            }
        }

        return nearestEntity;
    }
}
