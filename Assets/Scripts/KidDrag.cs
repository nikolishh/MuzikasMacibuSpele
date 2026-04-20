using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidDrag : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isDragging = false;
    public bool isPlaced = false;
    public string correctInstrument;
    public InstrumentGameManager gameManager;

    void Start()
    {
        startPosition = transform.position;

        if (gameManager == null)
        {
            gameManager = FindObjectOfType<InstrumentGameManager>();
        }
    }

    void OnMouseDown()
    {
        if (isPlaced) return;
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

        Collider2D kidCollider = GetComponent<Collider2D>();
        Collider2D[] hits = Physics2D.OverlapBoxAll(
            kidCollider.bounds.center,
            kidCollider.bounds.size,
            0f
        );

        bool snapped = false;

        foreach (Collider2D hit in hits)
        {
            Instrument instrument = hit.GetComponent<Instrument>();

            if (instrument != null && instrument.instrumentName == correctInstrument)
            {
                transform.position = instrument.standPoint.position;
                snapped = true;
                isPlaced = true;

                if (gameManager != null)
                    gameManager.PlayCorrect();

                break;
            }
        }

        if (!snapped)
        {
            transform.position = startPosition;

            if (gameManager != null)
                gameManager.PlayWrong();
        }
    }
}



