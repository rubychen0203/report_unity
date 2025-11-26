using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspectTrigger : MonoBehaviour
{
    [Header("UI 物件")]
    public GameObject interactHint;     // 按 E 提示
    public ItemInspectUI itemInspectUI; // 控制 RawImage + Text 的 UI Script

    [Header("物品設定")]
    public Texture itemTexture;          // RawImage 的圖片
    [TextArea(3, 10)]
    public string itemDescription;       // 文字描述

    private bool playerInRange = false;
    private bool isInspecting = false;

    void LateUpdate()
    {
        if (Camera.main != null)
            transform.LookAt(Camera.main.transform);
    }

    void Start()
    {
        interactHint.SetActive(false);
        itemInspectUI.Hide(); // 初始化隱藏
    }

    void Update()
    {
        // 玩家按 E 打開檢視
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isInspecting)
        {
            itemInspectUI.Show(itemTexture, itemDescription);
            interactHint.SetActive(false);
            isInspecting = true;

            // 解鎖滑鼠
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        // 玩家按 ESC 關閉檢視
        else if (isInspecting && Input.GetKeyDown(KeyCode.Escape))
        {
            itemInspectUI.Hide();
            isInspecting = false;

            // 如果玩家仍在範圍內，提示按 E
            if (playerInRange)
                interactHint.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (!isInspecting)
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
