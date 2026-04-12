using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    public GameObject confettiPrefab;

    public void OnCorrectPressed()
    {
        Instantiate(confettiPrefab, transform.position, Quaternion.identity);
    }
}
