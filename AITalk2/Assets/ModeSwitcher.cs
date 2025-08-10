using UnityEngine;

public class ModeSwitcher : MonoBehaviour
{
    public GameObject mainCamera;            // 聊天模式用的相機
    public GameObject followCamera;          // 角色控制用的相機

    public GameObject startMenuUI;           // 聊天UI
    public GameObject gameUI;                // 遊戲UI

    public GameObject player;                // 主角（開啟控制）
    public MonoBehaviour playerMoveScript;   // 角色移動腳本（如 PlayerMove）

    void Start()
    {
        SwitchToChatMode(); // 開始時先進入電腦模式
    }

    public void SwitchToGameMode()
    {
        Debug.Log("切換到 3D 模式");
        mainCamera.SetActive(false);
        followCamera.SetActive(true);

        startMenuUI.SetActive(false);
        gameUI.SetActive(true);

        if (playerMoveScript != null)
            playerMoveScript.enabled = true;
    }

    public void SwitchToChatMode()
    {
        Debug.Log("切換到 聊天模式");
        mainCamera.SetActive(true);
        followCamera.SetActive(false);

        startMenuUI.SetActive(true);
        gameUI.SetActive(false);

        if (playerMoveScript != null)
            playerMoveScript.enabled = false;
    }
}
