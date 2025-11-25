using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspectTrigger : MonoBehaviour
{
    [Header("UI 物件")]
    public GameObject interactHint;     // 「按 E」提示
    public GameObject inspectUI;        // 檢視 UI（Panel）
    public ItemInspectUI itemInspectUI; // 掛上 RawImage + Text 的腳本

    [Header("物品資料")]
    public Texture itemTexture;         // RawImage 用 Texture
    [TextArea(3, 10)]
    public string itemDescription;      // 顯示的說明文字

    private bool playerInRange = false;
    void LateUpdate()
    {
        if (Camera.main != null)
            transform.LookAt(Camera.main.transform);
    }
    void Start()
    {
        interactHint.SetActive(false);
        inspectUI.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // 顯示檢視 UI
            itemInspectUI.Show(itemTexture, itemDescription);
            interactHint.SetActive(false);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (inspectUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            // 關閉 UI
            inspectUI.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactHint.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactHint.SetActive(false);
        }
    }
}
