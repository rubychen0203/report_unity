using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonKeyTrigger : MonoBehaviour
{
    public Button targetButton;        // 指向你想觸發的按鈕
    public TMP_InputField inputField;  // 指向你想聚焦的 InputField

    public KeyCode submitKey = KeyCode.Return; // 按鈕觸發鍵（Enter）
    public KeyCode focusKey = KeyCode.T;      // 聚焦 InputField 鍵（T）

    void Update()
    {
        // 按 Enter 觸發按鈕
        if (Input.GetKeyDown(submitKey))
        {
            targetButton.onClick.Invoke();
        }

        // 按 T 聚焦 InputField
        if (Input.GetKeyDown(focusKey))
        {
            inputField.Select();
            inputField.ActivateInputField();
        }
    }
}
