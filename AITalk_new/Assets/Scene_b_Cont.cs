using UnityEngine;
using Flower;

public class SceneBController : MonoBehaviour
{
    private FlowerSystem fs;

    void Start()
    {
        // 1️⃣ 嘗試取得已存在的對話系統
        fs = FlowerManager.Instance.GetFlowerSystem("thema_fs");

        // 2️⃣ 如果不存在，就建立一個新的
        if (fs == null)
        {
            fs = FlowerManager.Instance.CreateFlowerSystem("thema_fs", false);
            Debug.Log("建立新的 FlowerSystem：thema_fs");
        }
        else
        {
            Debug.Log("使用既有的 FlowerSystem：thema_fs");
        }

        // 3️⃣ 重新顯示對話框（確保畫面有出現）
        fs.SetupDialog();

        // 4️⃣ 從上一個場景讀取要播放的劇本名稱
        string nextScript = PlayerPrefs.GetString("NextScript", "");

        if (!string.IsNullOrEmpty(nextScript))
        {
            fs.ReadTextFromResource(nextScript);
            Debug.Log("播放劇本：" + nextScript);
        }
        else
        {
            Debug.LogWarning("⚠️ 沒有設定要播放的劇本！");
        }
    }

    void Update()
    {
        // 玩家按空白鍵或滑鼠左鍵 → 播放下一句對話
        if (fs != null && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            fs.Next();
        }
    }
}
