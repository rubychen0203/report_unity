using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TableInteraction : MonoBehaviour
{
    public GameObject uiPanel;        // 2D聊天 UI
    public GameObject ui;             // 3DGameUI
    public InputField chatInputField; // 2D聊天 UI 的輸入欄位
    private bool isNearTable = false; // 判斷是否在桌子旁邊

    private void Update()
    {
        if (isNearTable && Input.GetKeyDown(KeyCode.E))
        {
            // 開啟 2D UI
            uiPanel.SetActive(true);
            // 關閉 3D UI
            ui.SetActive(false);

            // 🔹 選中 InputField
            if (chatInputField != null)
            {
                chatInputField.Select();
                chatInputField.ActivateInputField();
            }

            // 🔹 確保 EventSystem 存在
            if (FindObjectOfType<EventSystem>() == null)
            {
                GameObject es = new GameObject("EventSystem");
                es.AddComponent<EventSystem>();
                es.AddComponent<StandaloneInputModule>();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Table"))
        {
            isNearTable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Table"))
        {
            isNearTable = false;
            uiPanel.SetActive(false);
        }
    }
}
