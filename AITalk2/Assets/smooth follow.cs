using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;          // 設定為 FollowTarget
    public Vector3 offset = new Vector3(0, 1.5f, -4f);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + target.rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
