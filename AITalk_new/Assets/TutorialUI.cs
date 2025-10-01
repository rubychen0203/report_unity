using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    public GameObject tutorialPanel; // 指向 TutorialPanel
    public Button closeButton;       // 指向關閉按鈕

    void Start()
    {
        // 一開始顯示
        tutorialPanel.SetActive(true);

        // 點擊關閉按鈕時，關閉面板
        closeButton.onClick.AddListener(() =>
        {
            tutorialPanel.SetActive(false);
        });
    }
}
