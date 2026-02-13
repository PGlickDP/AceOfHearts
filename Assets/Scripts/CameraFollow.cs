using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Follow Settings")]
    public float smoothTime = 0.2f;
    public Vector3 offset = Vector3.zero;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate desired position
        Vector3 desiredPosition = target.position + offset;

        // Keep camera Z position fixed
        desiredPosition.z = transform.position.z;

        // Smoothly move the camera
        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref velocity,
            smoothTime
        );
    }
}