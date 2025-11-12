using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public string menuSceneName = "SampleScene"; // 主選單場景名稱
    public float waitTime = 5f; // 停留秒數

    void Start()
    {
        Debug.Log("🕒 GameOverScene 載入成功，將在 " + waitTime + " 秒後回主選單");
        StartCoroutine(ReturnToMenuAfterDelay());
    }

    private System.Collections.IEnumerator ReturnToMenuAfterDelay()
    {
        yield return new WaitForSeconds(waitTime);

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
}
