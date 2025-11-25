using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialPanel; // 將你的提示 Panel 拖進 Inspector
    public float displayTime = 5f;   // 顯示多久自動消失

    private void Start()
    {
        // 一開始顯示提示
        tutorialPanel.SetActive(true);
    }

    private void HideTutorial()
    {
        tutorialPanel.SetActive(false);
    }
    void Update()
{
    if (tutorialPanel.activeSelf && Input.GetKeyDown(KeyCode.E))
    {
        tutorialPanel.SetActive(false);
    }
}

}
