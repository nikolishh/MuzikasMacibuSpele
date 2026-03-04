using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KidHoverManager : MonoBehaviour
{
    public Transform kid;
    public GameObject thoughtBubble;
    public Vector3 offset = new Vector3(0, 50, 0);

    private KidDrag kidDrag;

    void Start()
    {
        thoughtBubble.SetActive(false);
        kidDrag = kid.GetComponent<KidDrag>();
        if (kidDrag == null)
        {
            Debug.LogError("KidDrag component not found on kid!");
        }
    }

    void Update()
    {
        if (kidDrag != null && kidDrag.isPlaced)
        {
            thoughtBubble.SetActive(false);
            return;
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(kid.position);
        thoughtBubble.transform.position = screenPos + offset;

        Vector3 mousePos = Input.mousePosition;
        Collider2D kidCollider = kid.GetComponent<Collider2D>();
        Bounds bounds = kidCollider.bounds;

        Vector3 min = Camera.main.WorldToScreenPoint(bounds.min);
        Vector3 max = Camera.main.WorldToScreenPoint(bounds.max);

        bool overKid =
            mousePos.x >= min.x &&
            mousePos.x <= max.x &&
            mousePos.y >= min.y &&
            mousePos.y <= max.y;

        RectTransform bubbleRect = thoughtBubble.GetComponent<RectTransform>();
        bool overBubble = RectTransformUtility.RectangleContainsScreenPoint(bubbleRect, mousePos);

        thoughtBubble.SetActive(overKid || overBubble);
    }
}


