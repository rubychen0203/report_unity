using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public string menuSceneName = "SampleScene"; // 主選單場景名稱

    // 按鈕點擊事件
    public void BackToMenu()
    {
        // 檢查場景是否在 Build Settings
        if (IsSceneInBuild(menuSceneName))
        {
            SceneManager.LoadScene(menuSceneName);
        }
        else
        {
            Debug.LogWarning($"場景 '{menuSceneName}' 沒有加入 Build Settings，無法載入！");
        }
    }

    // 判斷場景是否存在於 Build Settings
    private bool IsSceneInBuild(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (name == sceneName)
                return true;
        }
        return false;
    }
}
