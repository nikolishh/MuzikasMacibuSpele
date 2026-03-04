using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMove : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float travelTime;
    private float timer = 0f;

    private bool reachedLine = false; // to prevent overshooting

    public void Initialize(Vector3 target, float travelTime)
    {
        startPosition = transform.position;
        targetPosition = target;
        this.travelTime = travelTime;
        timer = 0f;
        reachedLine = false;
    }

    void Update()
    {
        if (travelTime <= 0f) return;

        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / travelTime); // clamp to 0–1

        transform.position = Vector3.Lerp(startPosition, targetPosition, t);

        // Mark reachedLine when t hits 1
        if (!reachedLine && t >= 1f)
        {
            reachedLine = true;
            // Don't destroy yet — wait for hit or miss
        }

        // Optional: destroy if it goes far past the line (miss)
        if (timer >= travelTime + 1f) // 1 second buffer
        {
            Destroy(gameObject); // note missed
        }
    }
}
