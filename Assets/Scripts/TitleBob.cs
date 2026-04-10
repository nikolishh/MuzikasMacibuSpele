using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBob : MonoBehaviour
{
    public RectTransform[] words;
    public float amplitude = 10f;
    public float speed = 2f;

    void Update()
    {
        for (int i = 0; i < words.Length; i++)
        {
            float offset = i * 0.5f;
            Vector2 pos = words[i].anchoredPosition;

            pos.y += Mathf.Sin(Time.time * speed + offset) * amplitude * Time.deltaTime;
            words[i].anchoredPosition = pos;
        }
    }
}
