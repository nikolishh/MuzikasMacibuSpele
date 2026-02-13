using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidDrag : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isDragging = false;
    public bool isPlaced = false; // NEW

    public string correctInstrument; // set in Inspector

    void Start()
    {
        startPosition = transform.position;
    }

    void OnMouseDown()
    {
        if (isPlaced) return; // can't drag if already placed
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging && !isPlaced)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }

    void OnMouseUp()
    {
        if (isPlaced) return;

        isDragging = false;

        // Check all colliders overlapping kid's collider
        Collider2D kidCollider = GetComponent<Collider2D>();
        Collider2D[] hits = Physics2D.OverlapBoxAll(kidCollider.bounds.center, kidCollider.bounds.size, 0f);

        bool snapped = false;

        foreach (Collider2D hit in hits)
        {
            Instrument instrument = hit.GetComponent<Instrument>();
            if (instrument != null && instrument.instrumentName == correctInstrument)
            {
                // Snap to the instrument's stand point
                transform.position = instrument.standPoint.position;
                snapped = true;
                isPlaced = true; // mark as placed
                break;
            }
        }

        if (!snapped)
        {
            // Return to start if wrong
            transform.position = startPosition;
        }
    }
}



