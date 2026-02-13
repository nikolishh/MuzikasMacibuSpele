using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KidHover : MonoBehaviour
{
    public GameObject thoughtBubble; // assign bubble in inspector

    [HideInInspector] public bool isHoveringKid = false;
    [HideInInspector] public bool isHoveringBubble = false;

    void Start()
    {
        thoughtBubble.SetActive(false);
    }

    public void OnKidPointerEnter()
    {
        isHoveringKid = true;
        UpdateBubble();
    }

    public void OnKidPointerExit()
    {
        isHoveringKid = false;
        UpdateBubble();
    }

    public void OnBubblePointerEnter()
    {
        isHoveringBubble = true;
        UpdateBubble();
    }

    public void OnBubblePointerExit()
    {
        isHoveringBubble = false;
        UpdateBubble();
    }

    void UpdateBubble()
    {
        thoughtBubble.SetActive(isHoveringKid || isHoveringBubble);
    }
}



