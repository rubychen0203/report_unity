using UnityEngine;

public class TableInteraction : MonoBehaviour
{
    public GameObject uiPanel;     // 要顯示的 UI
    private bool isNearTable = false; // 判斷是否在桌子旁邊

    private void Update()
    {
        // 如果在桌子旁邊，且按下 E
        if (isNearTable && Input.GetKeyDown(KeyCode.E))
        {
            uiPanel.SetActive(true); // 顯示 UI
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Table")) // 進入桌子範圍
        {
            isNearTable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Table")) // 離開桌子範圍
        {
            isNearTable = false;
            uiPanel.SetActive(false); // 離開時關閉 UI（可依需求拿掉）
        }
    }
}
