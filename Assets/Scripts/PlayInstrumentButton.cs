using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayInstrumentButton : MonoBehaviour
{
    public AudioClip instrumentSound;
    public AudioSource audioSource;

    public void PlaySound()
    {
        if (audioSource != null && instrumentSound != null)
        {
            audioSource.clip = instrumentSound;
            audioSource.Play();
        }
        else if (instrumentSound != null)
        {
            // fallback if no AudioSource: play at the current position
            AudioSource.PlayClipAtPoint(instrumentSound, transform.position);
        }
    }
}

