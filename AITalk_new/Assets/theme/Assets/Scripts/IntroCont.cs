using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class IntroCont : MonoBehaviour
{
private FlowerSystem fs;

// 🔹 使用靜態變數保證全局唯一
public static FlowerSystem CurrentFS;

void Awake()
{
    // 如果已經有 fs，就不用重建
    if (CurrentFS != null)
    {
        fs = CurrentFS;
        return;
    }

    fs = FlowerManager.Instance.CreateFlowerSystem("thema_fs", false);

    if (fs == null)
    {
        Debug.LogError("Failed to create FlowerSystem!");
        return;
    }

    CurrentFS = fs;

    // 保證 fs 不被場景切換銷毀
    DontDestroyOnLoad(fs.gameObject);
}

void Start()
{
    fs.SetupDialog();
    fs.ReadTextFromResource("Intro0");

    fs.RegisterCommand("load_scene", (List<string> _params) =>
    {
        if (_params.Count > 0)
            SceneManager.LoadScene(_params[0]);
    });
}

void Update()
{
    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
    {
        if (fs != null)
            fs.Next();
    }
}

// 🔹 這個方法可以綁給 UI 按鈕
public void SkipToNextScene()
{
    Debug.Log("Skip button pressed");

    if (fs != null)
    {
        fs.RemoveDialog();
        Debug.Log("Dialog removed");
    }
    else
    {
        Debug.LogWarning("fs is null! Dialog not removed.");
    }

    // 跳到下一個場景
    SceneManager.LoadScene("one");
}

}