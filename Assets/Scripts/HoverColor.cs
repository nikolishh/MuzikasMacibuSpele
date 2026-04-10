using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    Vector3 originalScale;
    Vector3 targetScale;
    public TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = new Color(1f, 1f, 1f, 0.9f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = new Color(1f, 1f, 1f, 1f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = originalScale * 0.9f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        targetScale = originalScale;
    }
}
