using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _detectRayLenght = 3f;
    [SerializeField] private LayerMask _visionLayers;

    private Transform _playerTransform;

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _detectRayLenght, _visionLayers);

        if (hit.collider != null &&
            hit.collider.TryGetComponent<PlayerProcessor>(out _))
        {
            _playerTransform = hit.transform;
        }
        else
        {
            _playerTransform = null;
        }
    }

    public bool IsPlayerDetected(out float direction)
    {
        direction = 0f;

        if (_playerTransform == null)
            return false;

        direction = Mathf.Sign(_playerTransform.position.x - transform.position.x);

        return true;
    }
}
