using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [Header("偵測")]
    public float interactRadius = 2.0f;
    public LayerMask interactableLayer; // 指定 Interactable 物件層

    [Header("UI")]
    public TextMeshProUGUI promptText; // 拖入 Canvas 上的 TMP Text

    Interactable currentInteractable;

    void Update()
    {
        FindNearestInteractable();
        UpdatePromptUI();

        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }

    void FindNearestInteractable()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, interactRadius, interactableLayer);
        float bestDist = float.MaxValue;
        currentInteractable = null;

        foreach (var c in hits)
        {
            Interactable it = c.GetComponentInParent<Interactable>(); // 支援放在子物件上
            if (it == null) continue;

            float d = Vector3.Distance(transform.position, it.transform.position);
            if (d < bestDist)
            {
                bestDist = d;
                currentInteractable = it;
            }
        }
    }

    void UpdatePromptUI()
    {
        if (promptText == null) return;

        if (currentInteractable != null)
            promptText.text = currentInteractable.promptMessage + " (按 E)";
        else
            promptText.text = "";
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
