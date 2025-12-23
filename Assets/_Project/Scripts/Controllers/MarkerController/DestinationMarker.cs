using UnityEngine;

public class DestinationMarker : MonoBehaviour
{
    private Transform _marker;
    private Transform _playerTransform;

    private const float CollectionDistance = 0.5f;

    public void Initialize(Transform marker, Transform playerTransform)
    {
        _marker = marker;
        _playerTransform = playerTransform;
        DisableMarker();
    }

    private void Update()
    {
        if (IsTargetReached())
            DisableMarker();
    }

    public void SetMarkerPosition(Vector3 targetPoint)
    {
        EnableMarker();
        _marker.transform.position = targetPoint;
    }

    private void EnableMarker() => _marker.gameObject.SetActive(true);

    private void DisableMarker() => _marker.gameObject.SetActive(false);

    private bool IsTargetReached() => Vector3.Distance(_playerTransform.position, _marker.transform.position) <= CollectionDistance;
}
