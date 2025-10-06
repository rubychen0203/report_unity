using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public static bool fromIntro = false; // 🔹 新增靜態變數

    private FlowerSystem fs;

    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        fs.SetupDialog();
        fs.ReadTextFromResource("Intro");
        fs.OnDialogFinished += HandleDialogFinished;
    }

    private void HandleDialogFinished()
    {
        Debug.Log("Intro 對話結束，切換到 SampleScene");

        // 🔹 記錄是從 Intro 來的
        fromIntro = true;
        SceneManager.LoadScene("SampleScene");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            fs.Next();
    }

    private void OnDestroy()
    {
        if (fs != null)
            fs.OnDialogFinished -= HandleDialogFinished;
    }
}

