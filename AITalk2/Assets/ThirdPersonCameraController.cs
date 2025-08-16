using UnityEngine;

public class SimpleOrbitCamera : MonoBehaviour
{
    public Transform target;           // 角色 Transform
    public float distance = 5f;        // 距離
    public float mouseSensitivity = 5f;

    private float yaw = 0f;
    private float pitch = 20f;

    void Start()
    {
        // 隱藏鼠標並鎖定於畫面中央
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 滑鼠移動控制角度
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -40f, 80f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        Vector3 negDistance = new Vector3(0, 0, -distance);
        Vector3 position = target.position + rotation * negDistance;

        transform.position = position;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
