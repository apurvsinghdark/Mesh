using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearInterpolation : MonoBehaviour
{
    public G01 g01;
    private void Start() {
        g01.LinearMovement += Movement;
    }
    public void Movement(float xValue, float zValue, float fValue)
    {
        StartCoroutine(LinearMovement(xValue, zValue, fValue));
    }
    IEnumerator LinearMovement(float xValue, float zValue, float fValue)
    {
        GameManager Pin = GameManager.instance;
        
        // do{
        //         Pin.turrent.parent = Pin.pin;
        //         Pin.pin.localPosition = Vector3.MoveTowards(Pin.pin.localPosition, new Vector3(zValue, xValue, 0), fValue * Time.deltaTime);
        //         Pin.turrent.parent = Pin.meshHolder;
        //         yield return null;
        //     }while( Vector2.Distance(Pin.pin.localPosition, new Vector3(zValue, 0, 0)) > 0.01f);

        if(xValue == 0)
        {
            // do{
            //     Pin.turrent.parent = Pin.pin;
            //     Pin.pin.localPosition = Vector3.MoveTowards(Pin.pin.localPosition, new Vector3(zValue, xValue, 0), fValue * Time.deltaTime);
            //     //Pin.turrent.localPosition += new Vector3(xValue,0,0) * Time.deltaTime;
            //     //Pin.pin.localPosition = new Vector3 (Pin.pin.localPosition.x + (zValue/34), Pin.pin.localPosition.y, Pin.pin.localPosition.z);
            //     //Pin.pin.localPosition.x = 1f;
            //     yield return null;
            // }while( Vector2.Distance(Pin.pin.localPosition, new Vector3(zValue, 0, 0)) > 0.01f);
        }
        
        // if(zValue == -0.66f)
        // {
            do{
                Pin.turrent_toolHolder.parent = Pin.pin;
                Pin.pin.localPosition = Vector3.MoveTowards(Pin.pin.localPosition, new Vector3(0, xValue, -xValue), fValue * Time.deltaTime);
                Pin.turrent_toolHolder.parent = Pin.meshHolder;
                yield return null;
            }while( Vector2.Distance(Pin.turrent_toolHolder.localPosition, new Vector3(-0.66f, xValue, 0)) > 0.01f);
        // }
    }
}