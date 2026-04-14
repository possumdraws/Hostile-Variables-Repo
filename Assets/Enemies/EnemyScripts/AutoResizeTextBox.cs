using TMPro;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(TextMeshProUGUI))]
public class AutoResizeTextBox : MonoBehaviour
{
    public Vector2 padding = new Vector2(10f, 10f); // Extra space around text

    private TextMeshProUGUI tmpText;
    private RectTransform rectTransform;

    void Awake()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
    }
}
