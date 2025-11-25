using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorInteraction : MonoBehaviour
{
    [Header("UI 提示文字（可放多個）")]
    public List<TextMeshProUGUI> hintTexts = new List<TextMeshProUGUI>();   // 可以放多個 TMP 文字物件

    [Header("門設定")]
    public Transform door;             // 門的 Transform
    public float openAngle = 90f;      // 開門角度
    public float speed = 2f;           // 開門速度

    private bool isPlayerNear = false;
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        if (door == null) door = transform;
        closedRotation = door.rotation;
        openRotation = door.rotation * Quaternion.Euler(0, openAngle, 0);

        // 一開始先隱藏所有提示
        foreach (var text in hintTexts)
        {
            if (text != null) text.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("玩家進入觸發區");
            isPlayerNear = true;

            foreach (var text in hintTexts)
            {
                if (text != null)
                {
                    text.text = isOpen ? "按下 E 關門" : "按下 E 開門";
                    text.gameObject.SetActive(true);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;

            foreach (var text in hintTexts)
            {
                if (text != null) text.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;

            foreach (var text in hintTexts)
            {
                if (text != null)
                    text.text = isOpen ? "按下 E 關門" : "按下 E 開門";
            }
        }

        // 門的平滑旋轉
        if (isOpen)
            door.rotation = Quaternion.Lerp(door.rotation, openRotation, Time.deltaTime * speed);
        else
            door.rotation = Quaternion.Lerp(door.rotation, closedRotation, Time.deltaTime * speed);
    }
}

