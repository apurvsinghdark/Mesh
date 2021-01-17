using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInterpolation : MonoBehaviour
{
    public G00 g00;

    float yValue;
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
            zValue = -3.58f;
            xValue = -3.100001f;
            //yValue = -0.62f;
            //Pin.pin.localPosition.z = new Vector3(0,0,yValue);

            do{
            Pin.turrent.parent = Pin.pin;
            Pin.pin.localPosition = new Vector3(zValue, xValue, Pin.pin.localPosition.z);
            Pin.turrent.parent = Pin.meshHolder;

            yield return null;
            }while( Vector2.Distance(Pin.pin.localPosition, new Vector3(zValue, xValue, Pin.pin.localPosition.z)) > 0.01f);
        }
        
        if(zValue != 0 && xValue != 0)
        {
            float percentZValue = (zValue/100) * 5;
            float percentXValue = (xValue/100) * 5;
            //Debug.Log(percentValue);
            float newXPosition = -3.58f - percentZValue;
            float newZPosition = -3.100001f + percentXValue;

            do{
                Pin.turrent.parent = Pin.pin;
                Pin.pin.localPosition = new Vector3(newXPosition, newZPosition, Pin.pin.localPosition.z);
                Pin.turrent.parent = Pin.meshHolder;

                yield return null;
            }while( Vector2.Distance(Pin.pin.localPosition, new Vector3(newXPosition, newZPosition, Pin.pin.localPosition.z)) > 0.01f);
        }
    }
}
