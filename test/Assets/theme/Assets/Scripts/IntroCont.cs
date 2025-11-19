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

    // 🔹 只移除音樂
    public void SkipToNextScene()
    {
        Debug.Log("Skip button pressed");

        // 移除對話框 UI
        if (fs != null)
        {
            fs.RemoveDialog();
            Debug.Log("Dialog removed");
        }
        else
        {
            Debug.LogWarning("fs is null! Dialog not removed.");
        }

        // 🔹 停掉所有背景音樂
        foreach (var audio in FindObjectsOfType<AudioSource>())
        {
            audio.Stop();
            // 如果不想刪掉物件，只停止音樂即可
            // Destroy(audio.gameObject); // 如果想刪掉音源也可以打開
        }

        // 跳到下一個場景
        SceneManager.LoadScene("one");
    }
}
