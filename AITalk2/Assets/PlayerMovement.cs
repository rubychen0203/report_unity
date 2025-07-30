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

        Vector3 move = transform.forward * v + transform.right * h;

        // 移動角色
        controller.Move(move * speed * Time.deltaTime);

        // 傳入動畫參數（長度才會是 0 ~ 1）
        animator.SetFloat("Speed", move.magnitude);
    }
}
