using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class StartMenuController : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject gameUI;
    public VideoPlayer videoPlayerObject; // 指向 VideoPlayerObject
    public Button startButton;            // Start 按鈕元件

    private void Start()
    {
        gameUI.SetActive(false);
        videoPlayerObject.gameObject.SetActive(false);

        // 為 startButton 設定點擊事件
        startButton.onClick.AddListener(PlayIntroAndStartGame);
    }

    public void PlayIntroAndStartGame()
    {
        startMenu.SetActive(false);
        videoPlayerObject.gameObject.SetActive(true);
        videoPlayerObject.Play();
        videoPlayerObject.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        videoPlayerObject.gameObject.SetActive(false);
        gameUI.SetActive(true);
    }
}
