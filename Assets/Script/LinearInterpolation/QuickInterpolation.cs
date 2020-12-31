using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInterpolation : MonoBehaviour
{
    public G00 g00;
    private void Start() {
        g00.QuickMovement += Movement;
    }
    public void Movement(float xValue, float zValue)
    {
        StartCoroutine(QuickMovement(xValue, zValue));
    }
    IEnumerator QuickMovement(float xValue, float zValue)
    {
        GameManager Pin = GameManager.instance;

        if(zValue == 0 && xValue == 0)
        {
            zValue = -2.9f;
            xValue = -3;
        }
        
        do{
            Pin.turrent.parent = Pin.pin;
            Pin.pin.localPosition = new Vector3(zValue, xValue, 0);
            Pin.turrent.parent = Pin.meshHolder;

            yield return null;
        }while( Vector2.Distance(Pin.pin.localPosition, new Vector3(zValue, xValue, 0)) > 0.01f);
    }
}
