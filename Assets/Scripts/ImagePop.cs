using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePop : MonoBehaviour
{
    public float popScale = 1.2f;
    public float duration = 0.25f;

    private Vector3 originalScale;
    private Coroutine popRoutine;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    void OnEnable()
    {
        Pop();
    }

    public void Pop()
    {
        if (popRoutine != null)
            StopCoroutine(popRoutine);

        popRoutine = StartCoroutine(PopRoutine());
    }

    IEnumerator PopRoutine()
    {
        transform.localScale = Vector3.zero;

        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;

            float progress = t / duration;

            float scale = Mathf.Lerp(0f, popScale, Mathf.Sin(progress * Mathf.PI * 0.5f));

            transform.localScale = Vector3.one * scale;

            yield return null;
        }

        transform.localScale = originalScale;
    }
}
