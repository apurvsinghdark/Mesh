using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolHolder : MonoBehaviour
{
    public M06 m06;

    [SerializeField] private Transform toolHolder;

    private void Start() {
        m06.ToolChange += ToolChange;
    }

    void ToolChange(float tValue)
    {
        Debug.Log(tValue);
        switch (tValue)
        {
            case 0102:
                toolHolder.localRotation = Quaternion.Euler(new Vector3(-115f,0f,0f));
                break;
            case 0101:
                toolHolder.localRotation = Quaternion.Euler(new Vector3(-55f,0f,0f));
                break;
            default:
                break;
        }
    }
}
