using UnityEngine;

public class GameQuit : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit Game");   // 在 Unity Editor 會看到訊息
        Application.Quit();       // 在 Build 出的遊戲中才會真的關閉
    }
}
