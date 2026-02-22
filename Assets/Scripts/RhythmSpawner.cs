using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform spawnPoint;

    public float[] noteTimes;  // when notes should appear
    private float timer = 0f;
    private int index = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (index < noteTimes.Length && timer >= noteTimes[index])
        {
            Instantiate(notePrefab, spawnPoint.position, Quaternion.identity);
            index++;
        }
    }
}
