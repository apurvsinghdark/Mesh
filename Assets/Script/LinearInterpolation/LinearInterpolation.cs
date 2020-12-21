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
        
        do{
            Pin.pin.position = Vector3.MoveTowards(Pin.pin.position, new Vector3(zValue , xValue, 0), fValue * Time.deltaTime);
            yield return null;
        }while( Vector2.Distance(Pin.pin.position, new Vector3(zValue, xValue, 0)) > 0.01f);
    }
}
