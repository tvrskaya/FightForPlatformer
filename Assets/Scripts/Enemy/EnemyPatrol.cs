using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private float _reachDistance = 0.1f;

    private int _currentTargetIndex;

    public float GetCurrentDirection()
    {
        UpdateCurrentTargetIndex();

        float direction = Mathf.Sign(_patrolPoints[_currentTargetIndex].transform.position.x - transform.position.x);

        return direction;
    }

    private void UpdateCurrentTargetIndex()
    {
        float distance = _patrolPoints[_currentTargetIndex].position.x - transform.position.x;

        if (Mathf.Abs(distance) < _reachDistance)
        {
            _currentTargetIndex++;
            _currentTargetIndex %= _patrolPoints.Length;
        }
    }
}
