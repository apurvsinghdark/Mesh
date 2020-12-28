﻿using UnityEngine;
using UnityEngine.EventSystems;

public class DownButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject pin;

    private void Update() {
        if (isPressed && GameManager.IsPower)
        {
            pin.transform.Translate(new Vector3(0, -10f, 0) * Time.deltaTime);
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
