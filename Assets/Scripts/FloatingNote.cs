using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingNote : MonoBehaviour
{
    public float speed = 2f;
    public float rotationSpeed = 100f;
    public Vector2 direction = Vector2.right;
    public bool isPaused;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        if (isPaused) return;

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }

    public void PlaySpawnPop(float targetScale)
    {
        StartCoroutine(PopInRoutine(targetScale));
    }

    IEnumerator PopInRoutine(float targetScale)
    {
        float time = 0f;
        float duration = 0.25f;

        transform.localScale = Vector3.zero;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            float scale = Mathf.SmoothStep(0f, targetScale, t);

            transform.localScale = Vector3.one * scale;

            yield return null;
        }

        transform.localScale = Vector3.one * targetScale;
    }
}
