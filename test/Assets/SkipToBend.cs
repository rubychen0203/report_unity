using UnityEngine;
using UnityEngine.SceneManagement;
using Flower;

public class SkipToBend: MonoBehaviour
{
    private FlowerSystem fs;

    void Start()
    {
        fs = FlowerManager.Instance.GetFlowerSystem("thema_fs");
    }

    // 逐行播放對話
    void Update()
    {
        if (fs != null && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            fs.Next();
        }
    }

    // Skip 按鈕事件
    public void SkipToEnd()
    {
        if (fs != null)
        {
            fs.Stop(); // 🔹 立即停止對話系統
        }
        fs.RemoveDialog();
        SceneManager.LoadScene("b_end"); // 跳到 a_end 場景
    }
}
