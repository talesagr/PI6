using UnityEngine;

public class FollowPlayerCamera: MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed;
    [SerializeField] float tiltAngle;

    private void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        Quaternion tiltRotation = Quaternion.Euler(tiltAngle, transform.eulerAngles.y, transform.eulerAngles.z);

        transform.rotation = tiltRotation;

        transform.LookAt(player);
    }
}
