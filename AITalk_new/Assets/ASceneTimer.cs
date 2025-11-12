using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ASceneTimer : MonoBehaviour
{
    public string nextSceneName = "GameOverScene"; // 要跳轉的場景名稱
    public float waitTimes = 5f; // 停留秒數

    void Start()
    {
        StartCoroutine(WaitAndLoad()); // 啟動協程
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(waitTimes);
        if (IsSceneInBuild(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("⚠️ 場景 '" + nextSceneName + "' 沒有加入 Build Settings！");
        }
    }

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
