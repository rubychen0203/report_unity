using UnityEngine;

public class ModeSwitcher : MonoBehaviour
{
    public GameObject chatUI;               // 聊天 UI（Overlay 模式）
    public GameObject gameUI;               // 遊戲 UI（Overlay 模式）

    public MonoBehaviour playerMoveScript;  // 角色移動腳本（如 PlayerMove）
    public Transform player;                // 角色本體
    public Transform thirdPersonCamera;     // 第三人稱相機
    public Transform playerHead;
    private Vector3 cameraOffset;           // 相機與角色的相對位置

void Start()
{
    cameraOffset = thirdPersonCamera.position - playerHead.position;


}



    void LateUpdate()
    {
        if (playerMoveScript != null && playerMoveScript.enabled)
        {
            thirdPersonCamera.position = playerHead.position + cameraOffset;
            thirdPersonCamera.LookAt(playerHead.position);
        }
    }

    public void SwitchToGameMode()
    {
        Debug.Log("切換到 3D 模式");
        chatUI.SetActive(false);
        gameUI.SetActive(true);

        if (playerMoveScript != null)
            playerMoveScript.enabled = true;
    }

    public void SwitchToChatMode()
    {
        Debug.Log("切換到 聊天模式");
        chatUI.SetActive(true);
        gameUI.SetActive(false);

        if (playerMoveScript != null)
            playerMoveScript.enabled = false;
    }
}