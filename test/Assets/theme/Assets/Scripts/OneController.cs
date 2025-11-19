using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Flower;

public class OneController : MonoBehaviour
{
    FlowerSystem fs;
    public GameObject choicePanel; // 拖 ChoicePanel 進來
    public string sceneA = "a"; // 要載入的場景A名稱
    public string sceneB = "b"; // 要載入的場景B名稱

    void Start()
    {
        fs = FlowerManager.Instance.GetFlowerSystem("thema_fs");
    }

    void Update()
    {
        if (fs != null && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            fs.Next();
        }
    }

    // 上面選項 → 設定要讀的劇本名稱並載入場景A
    public void PlayIntro1()
    {
        PlayerPrefs.SetString("NextScript", "Intro1"); // ✅ 暫存要播放的腳本名
        SceneManager.LoadScene(sceneA);
    }

    // 下面選項 → 設定要讀的劇本名稱並載入場景B
    public void PlayIntro2()
    {
        PlayerPrefs.SetString("NextScript", "Intro2");
        SceneManager.LoadScene(sceneB);
    }
}
