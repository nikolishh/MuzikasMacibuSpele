using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KidHoverManager : MonoBehaviour
{
    public Transform kid;             // the kid sprite
    public GameObject thoughtBubble;  // bubble UI
    public Vector3 offset = new Vector3(0, 50, 0); // pixels above kid

    void Start()
    {
        thoughtBubble.SetActive(false);
    }

    void Update()
    {
        //Position bubble above kid
        Vector3 screenPos = Camera.main.WorldToScreenPoint(kid.position);
        thoughtBubble.transform.position = screenPos + offset;

        //Check if mouse is over kid or bubble
        Vector3 mousePos = Input.mousePosition;

        // Kid rectangle in screen space
        Vector3 kidScreenPos = Camera.main.WorldToScreenPoint(kid.position);
        float kidWidth = 50f;   // approximate kid size in pixels
        float kidHeight = 50f;

        bool overKid = mousePos.x >= kidScreenPos.x - kidWidth / 2 &&
                       mousePos.x <= kidScreenPos.x + kidWidth / 2 &&
                       mousePos.y >= kidScreenPos.y - kidHeight / 2 &&
                       mousePos.y <= kidScreenPos.y + kidHeight / 2;

        // Bubble rectangle
        RectTransform bubbleRect = thoughtBubble.GetComponent<RectTransform>();
        bool overBubble = RectTransformUtility.RectangleContainsScreenPoint(bubbleRect, mousePos);

        thoughtBubble.SetActive(overKid || overBubble);
    }
}

