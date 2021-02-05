using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInterpolation : MonoBehaviour
{
    public G00 g00;

    float percentValue;
    float newPosition;
    float newYPosition;
    float newZPosition;

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

        if(zValue != 0 && xValue == 0 && !G00.IsVertical || zValue == 0 && xValue == 0 && !G00.IsVertical)
        {
            if(zValue == 0 && xValue == 0)
            {
                zValue = -140.4f;
                //xValue = -3.100001;
                newPosition = zValue;
            }else if(zValue != 0 && xValue == 0)
            {
                percentValue = (zValue/100) * 75f;
                //Debug.Log(percentValue);
                newPosition = -140.4f - percentValue;
                //newPosition = Pin.pin.localPosition.x - percentValue;
            }

            do{
                Pin.turrent.parent = Pin.pin;
                Pin.pin.localPosition = Vector3.MoveTowards(Pin.pin.localPosition, new Vector3(newPosition, Pin.pin.localPosition.y, Pin.pin.localPosition.z), 60f * Time.deltaTime);
                Pin.turrent.parent = Pin.meshHolder;
                yield return null;
            }while( Vector2.Distance(Pin.pin.localPosition, new Vector3(newPosition, Pin.pin.localPosition.y, Pin.pin.localPosition.z)) > 0.01f);
        }
        
        if(xValue != 0 && zValue == 0 && G00.IsVertical || zValue == 0 && xValue == 0 && G00.IsVertical)
        {
            //For Center Position
            if(zValue == 0 && xValue == 0)
            {
                //zValue = -2.9f;
                xValue = -3f;
                newYPosition = xValue;
            }else if(xValue != 0 && zValue == 0)
            {
                percentValue = (xValue/100) * 75f;
                //Debug.Log(percentValue);
                newYPosition = -3f - percentValue;
                //newZPosition = 0f + percentValue;
                //newPosition = Pin.pin.localPosition.x - percentValue;
            }

            do{
                Pin.turrent_toolHolder.parent = Pin.pin;
                Pin.pin.localPosition = Vector3.MoveTowards(Pin.pin.localPosition, new Vector3(Pin.pin.localPosition.x, newYPosition, Pin.pin.localPosition.z), 60f * Time.deltaTime);
                Pin.turrent_toolHolder.parent = Pin.turrent;
                yield return null;
            }while( Vector2.Distance(Pin.pin.localPosition, new Vector3(Pin.pin.localPosition.x, newYPosition, Pin.pin.localPosition.z)) > 0.01f);
        }
        
        if(zValue != 0 && xValue != 0)
        {
            float percentZValue = (zValue/100) * 75f;
            float percentXValue = (xValue/100) * 75f;
            //Debug.Log(percentValue);
            float newXPosition = -140.4f - percentZValue;
            float newZPosition = -3f - percentXValue;

            do{
                Pin.turrent.parent = Pin.pin;
                Pin.pin.localPosition = new Vector3(newXPosition, newZPosition, Pin.pin.localPosition.z);
                Pin.turrent.parent = Pin.meshHolder;

                yield return null;
            }while( Vector2.Distance(Pin.pin.localPosition, new Vector3(newXPosition, newZPosition, Pin.pin.localPosition.z)) > 0.01f);
        }
    }
}
