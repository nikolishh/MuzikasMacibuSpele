using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [Header("Prefab + Sprites")]
    public GameObject notePrefab;
    public Sprite[] noteSprites;

    [Header("Spawn Settings")]
    public float spawnRate = 0.4f;
    public float minY = -4f;
    public float maxY = 4f;
    public float spawnX = -10f;

    [Header("Lifetime")]
    public float destroyTime = 10f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnNote), 0f, spawnRate);
    }

    void SpawnNote()
    {
        float y = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, y, 0f);

        GameObject note = Instantiate(notePrefab, spawnPos, Quaternion.identity);

        SpriteRenderer sr = note.GetComponent<SpriteRenderer>();
        FloatingNote fn = note.GetComponent<FloatingNote>();
        sr.sprite = noteSprites[Random.Range(0, noteSprites.Length)];

        Color c = sr.color;
        c.a = Random.Range(0.6f, 0.9f);
        sr.color = c;

        sr.sprite = noteSprites[Random.Range(0, noteSprites.Length)];

        float scale = Random.Range(0.5f, 1.4f);

        fn.PlaySpawnPop(scale);

        float dirX = Random.value > 0.5f ? 1f : -1f;

        fn.direction = new Vector2(dirX, Random.Range(-0.2f, 0.2f));
        fn.speed = Random.Range(1f, 3f);
        fn.rotationSpeed = Random.Range(50f, 200f);

        Destroy(note, destroyTime);
    }
}