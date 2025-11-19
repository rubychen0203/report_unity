using UnityEngine;

public class ShowEPrompt : MonoBehaviour
{
    public GameObject promptUI; // 指向你的 E_Prompt UI

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 玩家進入
        {
            promptUI.SetActive(true); // 顯示提示
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 玩家離開
        {
            promptUI.SetActive(false); // 隱藏提示
        }
    }
}
