using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; // 必須引入 EventSystem

public class StartMenuController : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject gameUI;         // 🔹 3DGameUI
    public Button startButton;
    public InputField chatInputField; // 🔹 3DGameUI 的聊天輸入欄位

    private void Start()
    {
        startButton.onClick.AddListener(StartIntroScene);

        // 🔹 如果是從 Intro 回來，直接顯示 3DGameUI
        if (IntroController.fromIntro)
        {
            startMenu.SetActive(false);
            gameUI.SetActive(true);
            IntroController.fromIntro = false; // 用完就清掉

            // 🔹 強制選中 InputField
            if (chatInputField != null)
            {
                chatInputField.Select();
                chatInputField.ActivateInputField();
            }

            // 🔹 確保 EventSystem 存在
            if (FindObjectOfType<EventSystem>() == null)
            {
                GameObject es = new GameObject("EventSystem");
                es.AddComponent<EventSystem>();
                es.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
            }
        }
        else
        {
            startMenu.SetActive(true);
            gameUI.SetActive(false);
        }
    }

    private void StartIntroScene()
    {
        startMenu.SetActive(false);
        SceneManager.LoadScene("Intro");
    }
}
