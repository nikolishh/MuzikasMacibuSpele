using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmGameManager : MonoBehaviour
{
    public GameObject startButton;
    public AudioSource introSound;
    public RhythmSpawner spawner;
    public RhythmHitManager hitManager;

    void Start()
    {
        spawner.enabled = false;
        hitManager.enabled = false;
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        StartCoroutine(BeginAfterIntro());
    }

    IEnumerator BeginAfterIntro()
    {
        introSound.Play();
        yield return new WaitForSeconds(introSound.clip.length);

        spawner.enabled = true;
        hitManager.enabled = true;
    }
}
