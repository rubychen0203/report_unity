using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class OneController : MonoBehaviour
{
FlowerSystem fs;
public GameObject choicePanel; // 拖 ChoicePanel 進來

void Start()
{
    fs = FlowerManager.Instance.GetFlowerSystem("thema_fs");
    // 一開始不讀，等玩家選擇
}

void Update()
{
    if (fs != null && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
    {
        fs.Next();
    }
}

// 上面選項：播放 intro1
public void PlayIntro1()
{
    if (fs != null)
    {
        fs.SetupDialog(); // 🔹 重新顯示對話框
        fs.ReadTextFromResource("Intro1");
    }
    choicePanel.SetActive(false); // 關閉選項
}

// 下面選項：播放 intro2
public void PlayIntro2()
{
    if (fs != null)
    {
        fs.SetupDialog(); // 🔹 重新顯示對話框
        fs.ReadTextFromResource("Intro2");
    }
    choicePanel.SetActive(false); // 關閉選項
}


}
