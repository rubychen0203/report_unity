using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    public static bool fromIntro = false;
    private FlowerSystem fs;

    [Header("UI 元件")]
    public Button skipButton;

    void Start()
    {
        // 建立 FlowerSystem（不使用 DontDestroyOnLoad）
        fs = FlowerManager.Instance.CreateFlowerSystem("intro_fs", false);
        fs.SetupDialog();
        fs.ReadTextFromResource("Intro");

        // 對話結束事件
        fs.OnDialogFinished += HandleDialogFinished;

        // 綁定 Skip 按鈕
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(OnSkipClicked);
        }
    }

    void Update()
    {
        if (fs != null && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            fs.Next();
        }
    }

    private void HandleDialogFinished()
    {
        Debug.Log("Intro 對話結束，切換到 SampleScene");
        ChangeScene("SampleScene");
    }

    private void OnSkipClicked()
    {
        Debug.Log("玩家按下 Skip，停止對話並切換到 3D 場景");
        ClearFlowerBackground();
        ChangeScene("SampleScene");
    }

    private void ClearFlowerBackground()
{
    var objects = GameObject.FindObjectsOfType<GameObject>();

    foreach (var obj in objects)
    {
        if (obj.name.Contains("BG") || obj.name.Contains("char")|| obj.name.Contains("bg"))
        {
            Destroy(obj);
        }
    }
}
    // 🔹 清理所有 FlowerSystem 物件
    private void ClearFlowerObjects()
    {
        if (fs != null)
        {
            fs.Stop();
            fs.RemoveDialog();

            // 1️⃣ 刪掉 FlowerSystem 本身
            Destroy(fs.gameObject);
            fs = null;
        }

        // 2️⃣ 尋找所有花系統生成的物件（背景、音樂、UI 等）
        // 這裡假設 Flower 生成物件名稱含 "Flower" 或 "fs"
        var flowerObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (var obj in flowerObjects)
        {
            if (obj.name.Contains("Flower") || obj.name.Contains("fs") || obj.GetComponent<AudioSource>() != null)
            {
                Destroy(obj);
            }
        }

        // 3️⃣ 停止所有背景音樂，保險起見
        var audios = FindObjectsOfType<AudioSource>();
        foreach (var a in audios)
        {
            a.Stop();
            Destroy(a.gameObject);
        }
    }

    private void ChangeScene(string sceneName)
    {
        ClearFlowerObjects();
        fromIntro = true;
        SceneManager.LoadScene(sceneName);
    }

    private void OnDestroy()
    {
        if (fs != null)
        {
            fs.OnDialogFinished -= HandleDialogFinished;
        }
    }
}
