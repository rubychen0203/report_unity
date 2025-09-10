using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;      // 重力大小
    public float groundCheckDistance = 0.2f; // 判斷是否落地的距離
    public Transform cameraTransform;   // 拖入相機

    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;           // 儲存角色的垂直速度（重力用）
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // --- 地面檢查 ---
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 小於0就重設，避免角色浮空
        }

        // --- 移動輸入 ---
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 取得相機方向（忽略 Y 軸）
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0;
        camRight.Normalize();

        // 根據相機計算移動方向
        Vector3 move = camForward * v + camRight * h;

        // 如果有輸入，就旋轉角色朝向
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(move),
                Time.deltaTime * 10f
            );
        }

        // --- 移動角色（水平方向） ---
        controller.Move(move.normalized * speed * Time.deltaTime);

        // --- 重力處理 ---
        velocity.y += gravity * Time.deltaTime; 
        controller.Move(velocity * Time.deltaTime);

        // --- 更新動畫參數 ---
        animator.SetFloat("Speed", move.magnitude);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("撞到：" + hit.gameObject.name);
    }
}
