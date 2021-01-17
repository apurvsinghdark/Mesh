using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////Issues need to fix
//Timefix For Multiple Carve in old no.
//DirtParticle


public class LinearInterpolation : MonoBehaviour
{
    public G01 g01;
    bool isMoving = false;
    float percentValue;
    float newPosition;
    float newYPosition;
    float newZPosition;
    float yValue;

    public static float timeScale;
    float cutRate;
    [SerializeField]float cutRateModifier;

    private void Start() {
        g01.LinearMovement += Movement;
        cutRateModifier = 1;
    }
    public void Movement(float xValue, float zValue, float fValue)
    {
        StartCoroutine(MultipleCarve(xValue, zValue, fValue));
        //StartCoroutine(LinearMovement(xValue, zValue, fValue));

        timeScale = Mathf.Abs((xValue + zValue)/fValue);

        if(timeScale == 0)
        {
            timeScale = 0.5f;
        }

        //For Iron Cutting Speed is @245m/s
        //Scaled Value For 5% of given Value
        //5% of Cutting Speed is 12.25
        //For Fixed frame Variable 12.25 - 10

        cutRate = 2.25f; // equal to 2.25;
    }
    
    IEnumerator MultipleCarve(float xValue, float zValue, float fValue) {
        if(xValue == 0 && zValue == 0 || xValue == 0 && zValue != 0 || xValue != 0 && zValue == 0)
        {
           StartCoroutine(LinearMovement(xValue,zValue,fValue));
           //LinearMovement(xValue,zValue,fValue);
        }
        else{

            float R = 10 - xValue;
            if( R % 2 == 0 )
            {
                float r = 0;
                do{
                    //float z = zValue;
                    G01.IsHorizontal = false;
                    StartCoroutine(LinearMovement(xValue + 2, 0, fValue));
                    //Debug.Log(fValue);
                    yield return new WaitForSeconds(0.5f);
                    StopCoroutine(LinearMovement(xValue + 2, 0, fValue));
                    G01.IsHorizontal = true;
                    StartCoroutine(LinearMovement(0, zValue, cutRate * cutRateModifier));
                    yield return new WaitForSeconds(0.5f);
                    StopCoroutine(LinearMovement(0, zValue, cutRate * cutRateModifier));
                    
                    xValue -= 2;
                    r += 2;
                    //Debug.Log(r);
                    
                    if(r != R)
                    {
                        StartCoroutine(LinearMovement(0, 0, fValue));
                        yield return new WaitForSeconds(0.5f);
                        StopCoroutine(LinearMovement(0, 0, fValue));
                        yield return new WaitForSeconds(0.5f);
                        G01.IsHorizontal = false;
                    }
                    
                    G01.IsHorizontal = false;

                }while(r < R);
            }


        }
        //yield return null;
    }
    
    IEnumerator LinearMovement(float xValue, float zValue, float fValue)
    {
        GameManager Pin = GameManager.instance; //INSTANCE OF CHISEL

        if(zValue != 0 && xValue == 0 && G01.IsHorizontal || zValue == 0 && xValue == 0 && G01.IsHorizontal)
        {
            //For Center Position
            if(zValue == 0 && xValue == 0)
            {
                zValue = -3.58f;
                //xValue = -3.100001;
                newPosition = zValue;
            }else if(zValue != 0 && xValue == 0)
            {
                percentValue = (zValue/100) * 5;
                //Debug.Log(percentValue);
                newPosition = -3.58f - percentValue;
                //newPosition = Pin.pin.localPosition.x - percentValue;
            }

            do{
                Pin.turrent.parent = Pin.pin;
                Pin.pin.localPosition = Vector3.MoveTowards(Pin.pin.localPosition, new Vector3(newPosition, Pin.pin.localPosition.y, Pin.pin.localPosition.z), fValue * Time.deltaTime);
                Pin.turrent.parent = Pin.meshHolder;
                yield return null;
            }while( Vector2.Distance(Pin.pin.localPosition, new Vector3(newPosition, Pin.pin.localPosition.y, Pin.pin.localPosition.z)) > 0.01f);
        }

        if(xValue != 0 && zValue == 0 && !G01.IsHorizontal || zValue == 0 && xValue == 0 && !G01.IsHorizontal)
        {
            //For Center Position
            if(zValue == 0 && xValue == 0)
            {
                //zValue = -2.9f;
                xValue = -3.100001f;
                yValue = -0.3f; //-0.62;
                newYPosition = xValue;
                newZPosition = yValue;
            }else if(xValue != 0 && zValue == 0)
            {
                percentValue = (xValue/100) * 5;
                //Debug.Log(percentValue);
                newYPosition = -3.100001f - percentValue;
                //newZPosition = 0f + percentValue;
                //newPosition = Pin.pin.localPosition.x - percentValue;
            }

            do{
                Pin.turrent_toolHolder.parent = Pin.pin;
                Pin.pin.localPosition = Vector3.MoveTowards(Pin.pin.localPosition, new Vector3(Pin.pin.localPosition.x, newYPosition, Pin.pin.localPosition.z), fValue * Time.deltaTime);
                Pin.turrent_toolHolder.parent = Pin.turrent;
                yield return null;
            }while( Vector2.Distance(Pin.pin.localPosition, new Vector3(Pin.pin.localPosition.x, newYPosition, Pin.pin.localPosition.z)) > 0.01f);
        }
    }
}
