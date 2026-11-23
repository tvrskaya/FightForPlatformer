using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _detectRayLenght = 3f;
    [SerializeField] private LayerMask _visionLayers;
    [SerializeField] private Transform _facingTransform;

    private Transform _playerTransform;

    private void FixedUpdate()
    {
        Transform facingTransform = _facingTransform != null ? _facingTransform : transform;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facingTransform.right, _detectRayLenght, _visionLayers);

        if (hit.collider != null &&
            hit.collider.TryGetComponent<Player>(out _))
        {
            _playerTransform = hit.transform;
        }
        else
        {
            _playerTransform = null;
        }
    }

    public bool IsPlayerDetected(out float direction, out float distance)
    {
        direction = 0f;
        distance = 0f;

        if (_playerTransform == null)
            return false;

        distance = _playerTransform.position.x - transform.position.x;
        direction = Mathf.Sign(distance);

        return true;
    }
}
