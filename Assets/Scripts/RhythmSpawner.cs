using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform spawnPoint;
    public Transform hitLine;

    public float[] noteTimes;
    public float noteTravelTime = 1f;

    private float timer = 0f;
    private int index = 0;

    void OnEnable()
    {
        timer = 0f;
        index = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (index < noteTimes.Length && timer >= noteTimes[index] - noteTravelTime)
        {
            GameObject note = Instantiate(notePrefab, spawnPoint.position, Quaternion.identity);
            note.GetComponent<NoteMove>().Initialize(hitLine.position, noteTravelTime);
            index++;
        }
    }
}
