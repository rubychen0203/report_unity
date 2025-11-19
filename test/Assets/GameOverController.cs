using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameOverController : MonoBehaviour
{
    public string menuSceneName = "SampleScene";
    public float waitTime = 5f;

    void Start()
    {
        Debug.Log("🕒 GameOverScene 載入成功，將在 " + waitTime + " 秒後回主選單");
        StartCoroutine(ReturnToMenuAfterDelay());
    }

    private System.Collections.IEnumerator ReturnToMenuAfterDelay()
    {
        yield return new WaitForSeconds(waitTime);

        // 🔹 切場景前：全部清乾淨
        CleanUpPersistentObjects();

        if (IsSceneInBuild(menuSceneName))
        {
            Debug.Log("✅ 時間到，載入主選單：" + menuSceneName);
            SceneManager.LoadScene(menuSceneName);
        }
        else
        {
            Debug.LogWarning($"⚠️ 場景 '{menuSceneName}' 沒有加入 Build Settings！");
        }
    }

    // 判斷場景是否存在於 Build Settings
    private bool IsSceneInBuild(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (name == sceneName)
                return true;
        }
        return false;
    }

    // 🔥🔥🔥　這裡會清掉所有殘留物　🔥🔥🔥
    private void CleanUpPersistentObjects()
    {
        Debug.Log("🧹 清理殘留的音樂、影片、對話框、背景物件…");

        // 1️⃣ 停止所有音樂
        foreach (var audio in FindObjectsOfType<AudioSource>())
        {
            audio.Stop();
        }

        // 2️⃣ 停止所有影片
        foreach (var video in FindObjectsOfType<VideoPlayer>())
        {
            video.Stop();
        }

        // 3️⃣ 移除 FlowerSystem（如果有使用 Flower 對話系統）
        var flowerSystem = GameObject.FindObjectOfType<Flower.FlowerSystem>();
        if (flowerSystem != null)
        {
            Destroy(flowerSystem.gameObject);
            Debug.Log("🗑️ FlowerSystem 移除");
        }

        // 4️⃣ 把 DontDestroyOnLoad 的物件一起清掉
        var roots = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var go in roots)
        {
            if (go.scene.name == null || go.scene.name == "") 
            {
                // 這些是 DontDestroyOnLoad 的物件
                Destroy(go);
            }
        }

        Debug.Log("✨ 清理完成，準備切場景");
    }
}
