using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform; // 把 Main Camera 拖進來

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 取得相機的前方向與右方向（忽略 Y 軸）
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0;
        camRight.Normalize();

        // 根據相機方向計算移動
        Vector3 move = camForward * v + camRight * h;

        // 如果有移動，就旋轉角色面對移動方向
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(move),
                Time.deltaTime * 10f
            );
        }

        // 移動角色
        controller.Move(move.normalized * speed * Time.deltaTime);

        // 更新動畫參數
        animator.SetFloat("Speed", move.magnitude);
    }
}
