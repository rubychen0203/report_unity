using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
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

        Vector3 move = new Vector3(h, 0, v);

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

        // 傳入動畫參數
        animator.SetFloat("Speed", move.magnitude);
    }
}
