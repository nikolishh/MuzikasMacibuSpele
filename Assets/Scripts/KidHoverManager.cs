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
        // Get the kid's collider
        Collider2D kidCollider = kid.GetComponent<Collider2D>();
        Bounds bounds = kidCollider.bounds;

        // Convert world bounds to screen space
        Vector3 min = Camera.main.WorldToScreenPoint(bounds.min);
        Vector3 max = Camera.main.WorldToScreenPoint(bounds.max);

        // Check if mouse is inside real collider bounds
        bool overKid =
            mousePos.x >= min.x &&
            mousePos.x <= max.x &&
            mousePos.y >= min.y &&
            mousePos.y <= max.y;

        //Check if mouse is over bubble (UI)
        RectTransform bubbleRect = thoughtBubble.GetComponent<RectTransform>();
        bool overBubble = RectTransformUtility.RectangleContainsScreenPoint(bubbleRect, mousePos);

        //Set bubble active only if hovering kid or bubble
        thoughtBubble.SetActive(overKid || overBubble);
    }
}


