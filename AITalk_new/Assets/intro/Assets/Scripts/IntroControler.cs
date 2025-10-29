using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // ← 要控制 UI 按鈕需要這個命名空間

public class IntroController : MonoBehaviour
{
    public static bool fromIntro = false; // 🔹 用來記錄是從 Intro 來的
    private FlowerSystem fs;

    [Header("UI 元件")]
    public Button skipButton; // 🎯 在 Inspector 拖進你的 Skip 按鈕

    void Start()
    {
        // 建立對話系統
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        fs.SetupDialog();
        fs.ReadTextFromResource("Intro");

        // 對話結束事件
        fs.OnDialogFinished += HandleDialogFinished;

        // 綁定 Skip 按鈕事件（如果你有加按鈕）
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(OnSkipClicked);
        }
    }

    private void HandleDialogFinished()
    {
        Debug.Log("Intro 對話結束，切換到 SampleScene");

        fromIntro = true;
        SceneManager.LoadScene("SampleScene");
    }

    // 🎬 當按下 Skip 時
    private void OnSkipClicked()
    {
        Debug.Log("玩家按下 Skip，停止對話並切換到 3D 場景");

        if (fs != null)
        {
            fs.Stop(); // 🔹 立即停止對話系統
        }
        fs.RemoveDialog();

        fromIntro = true;
        SceneManager.LoadScene("SampleScene");
    }

    void Update()
    {
        // 這段保留：空白鍵繼續劇情
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
            fs.Next();
    }

    private void OnDestroy()
    {
        if (fs != null)
            fs.OnDialogFinished -= HandleDialogFinished;
    }
}
