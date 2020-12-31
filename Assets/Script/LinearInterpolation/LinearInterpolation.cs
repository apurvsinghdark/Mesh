using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearInterpolation : MonoBehaviour
{
    public G01 g01;
    bool isMoving = false;
    float percentValue;
    float newPosition;

    private void Start() {
        g01.LinearMovement += Movement;
    }
    public void Movement(float xValue, float zValue, float fValue)
    {
        StartCoroutine(LinearMovement(xValue, zValue, fValue));
    }
    IEnumerator LinearMovement(float xValue, float zValue, float fValue)
    {
        GameManager Pin = GameManager.instance; //INSTANCE OF CHISEL

        if(zValue != 0 && xValue == 0 || zValue == 0 && xValue == 0)
        {
            //For Center Position
            if(zValue == 0 && xValue == 0)
            {
                zValue = -2.9f;
                //xValue = -3;
                newPosition = zValue;
            }else if(zValue != 0 && xValue == 0)
            {
                percentValue = (zValue/100) * 5;
                //Debug.Log(percentValue);
                newPosition = Pin.pin.localPosition.x + percentValue;
            }

            do{
                Pin.turrent.parent = Pin.pin;
                Pin.pin.localPosition = Vector3.MoveTowards(Pin.pin.localPosition, new Vector3(newPosition, Pin.pin.localPosition.y, Pin.pin.localPosition.z), fValue * Time.deltaTime);
                Pin.turrent.parent = Pin.meshHolder;
                yield return null;
            }while( Vector2.Distance(Pin.pin.localPosition, new Vector3(newPosition, Pin.pin.localPosition.y, Pin.pin.localPosition.z)) > 0.01f);
        }

        if(xValue != 0 && zValue == 0 || zValue == 0 && xValue == 0)
        {
            //For Center Position
            if(zValue == 0 && xValue == 0)
            {
                zValue = -2.9f;
                //xValue = -3;
            }

            if(isMoving)
            {
                yield break;
            }

            isMoving = true;

            float counter = 0;

            Vector3 startPos = Pin.pin.localPosition;
            //Vector3 toPos = new Vector3(Pin.pin.position.x, Pin.pin.localPosition.y + xValue, Pin.pin.localPosition.z - xValue);

            while(counter < fValue)
            {
                counter += Time.deltaTime;
                Pin.turrent_toolHolder.parent = Pin.pin;
                //Pin.pin.localPosition = Vector3.Lerp(startPos, toPos, counter / fValue);
                Pin.pin.localPosition += new Vector3(0f, xValue/4, -xValue/4) * fValue * Time.deltaTime;
                Pin.turrent_toolHolder.parent = Pin.turrent;
                yield return null;
            }

            isMoving = false;
        }
    }
}