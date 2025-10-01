using UnityEngine;

public class Interactable : MonoBehaviour
{
    [TextArea(1,3)]
    public string promptMessage = "按 E 互動";

    // 當玩家按下互動鍵時會被呼叫（子類別覆寫）
    public virtual void Interact()
    {
        Debug.Log($"Interacted with {gameObject.name}");
    }
}
