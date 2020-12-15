﻿using UnityEngine;
using UnityEngine.EventSystems;

public class DownButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject pin;

    private void Update() {
        if (isPressed && GameManager.IsPower)
        {
            pin.transform.Translate(0, -0.1f, 0);
        }    
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}