using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmHitManager : MonoBehaviour
{
    public Transform hitLine;
    public float hitWindow = 0.7f; // how close is allowed
    public AudioSource clapSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckForHit();
        }
    }

    void CheckForHit()
    {
        NoteMove[] notes = FindObjectsOfType<NoteMove>();

        foreach (NoteMove note in notes)
        {
            float distance = Mathf.Abs(note.transform.position.x - hitLine.position.x);

            if (distance <= hitWindow)
            {
                clapSound.Play();
                Destroy(note.gameObject);
                return; // only hit one note
            }
        }

        Debug.Log("MISS!");
    }
}
