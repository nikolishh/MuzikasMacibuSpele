using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableNote : MonoBehaviour
{
    private FloatingNote floatingNote;
    private Camera cam;

    void Start()
    {
        floatingNote = GetComponent<FloatingNote>();
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                floatingNote.isPaused = true;
            }
        }

        if (Input.GetMouseButton(0) && floatingNote.isPaused)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            floatingNote.isPaused = false;
        }
    }
}
