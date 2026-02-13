using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KidHoverManager : MonoBehaviour
{
    public Transform kid;             // the kid sprite
    public GameObject thoughtBubble;  // bubble UI
    public Vector3 offset = new Vector3(0, 50, 0); // pixels above kid

    private KidDrag kidDrag;          // reference to KidDrag script

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
        //If the kid is already placed, hide the bubble and exit
        if (kidDrag != null && kidDrag.isPlaced)
        {
            thoughtBubble.SetActive(false);
            return;
        }

        //Position bubble above kid
        Vector3 screenPos = Camera.main.WorldToScreenPoint(kid.position);
        thoughtBubble.transform.position = screenPos + offset;

        //Check if mouse is over kid (world space)
        Vector3 mousePos = Input.mousePosition;
        Vector3 kidScreenPos = Camera.main.WorldToScreenPoint(kid.position);

        float kidWidth = 50f;   // approximate kid size in pixels
        float kidHeight = 50f;

        bool overKid = mousePos.x >= kidScreenPos.x - kidWidth / 2 &&
                       mousePos.x <= kidScreenPos.x + kidWidth / 2 &&
                       mousePos.y >= kidScreenPos.y - kidHeight / 2 &&
                       mousePos.y <= kidScreenPos.y + kidHeight / 2;

        //Check if mouse is over bubble (UI)
        RectTransform bubbleRect = thoughtBubble.GetComponent<RectTransform>();
        bool overBubble = RectTransformUtility.RectangleContainsScreenPoint(bubbleRect, mousePos);

        //Set bubble active only if hovering kid or bubble
        thoughtBubble.SetActive(overKid || overBubble);
    }
}


