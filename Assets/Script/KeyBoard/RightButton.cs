using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour , IPointerDownHandler , IPointerUpHandler
{
    bool isPressed = false;
    public GameObject pin;

    private void Update() {
        if (isPressed)
        {
            pin.transform.Translate(0.2f, 0, 0);
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
