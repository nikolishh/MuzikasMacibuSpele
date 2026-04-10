using UnityEngine;
using System.Collections;

public class ButtonIntro : MonoBehaviour
{
    public Vector3 startOffset = new Vector3(-300f, 0f, 0f);
    public float duration = 0.5f;
    public float delay = 0f;

    CanvasGroup canvasGroup;
    Vector3 startPos;
    Vector3 targetPos;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        targetPos = transform.localPosition;
        startPos = targetPos + startOffset;

        transform.localPosition = startPos;
        canvasGroup.alpha = 0f;

        StartCoroutine(AnimateIn());
    }

    IEnumerator AnimateIn()
    {
        yield return new WaitForSeconds(delay);

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / duration;

            float eased = Mathf.SmoothStep(0f, 1f, t);

            transform.localPosition = Vector3.Lerp(startPos, targetPos, eased);
            canvasGroup.alpha = eased;

            yield return null;
        }

        transform.localPosition = targetPos + Vector3.right * 15f;

        float bounceTime = 0f;
        float bounceDuration = 0.2f;

        while (bounceTime < 1f)
        {
            bounceTime += Time.deltaTime / bounceDuration;

            float eased = Mathf.SmoothStep(0f, 1f, bounceTime);

            transform.localPosition = Vector3.Lerp(
                targetPos + Vector3.right * 15f,
                targetPos,
                eased
            );

            yield return null;
        }

        transform.localPosition = targetPos;
        canvasGroup.alpha = 1f;
    }
}