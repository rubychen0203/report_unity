using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;      // 指向 Player 的 Transform
    public Vector3 offset = new Vector3(0, 2, -4); // 高度 + 後退距離
    public float smoothSpeed = 0.125f;             // 平滑跟隨速度

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + player.transform.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
