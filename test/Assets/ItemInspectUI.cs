using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // 用於 TextMeshProUGUI

public class ItemInspectUI : MonoBehaviour
{
    public RawImage rawImage;               // 顯示物品圖片
    public TextMeshProUGUI descriptionText; // 顯示物品說明文字

    public void Show(Texture texture, string description)
    {
        gameObject.SetActive(true);
        rawImage.texture = texture;
        descriptionText.text = description;
        Debug.Log("Show UI Triggered");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

