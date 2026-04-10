using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float amplitude = 1f;
    public float speed = 0.5f;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = startPos + new Vector3(x, 0, 0);
    }
}
