using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    [Header("Turrent Parts")]
    [SerializeField] Transform tool_Holder;
    [SerializeField] Transform tool_VertPart;
    [SerializeField] Transform tool_HorizPart;

    private void Update() {
        TurrentMovement();
        TurrentRotation();
    }

    void TurrentMovement()
    {
        //Turrent Vertical Movement
        if(Input.GetKey(KeyCode.A))
            tool_VertPart.localPosition += new Vector3(1f,0f,0f) * Time.deltaTime;
        
        if(Input.GetKey(KeyCode.D))
            tool_VertPart.localPosition += new Vector3(-1f,0f,0f) * Time.deltaTime;


        // Turrent Horizontal Movement
        if(Input.GetKey(KeyCode.W))
            tool_HorizPart.localPosition += new Vector3(0f,1f,-1f) * Time.deltaTime;
        
        if(Input.GetKey(KeyCode.S))
            tool_HorizPart.localPosition += new Vector3(0f,-1f,1f) * Time.deltaTime;
    }

    void TurrentRotation()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
            tool_Holder.Rotate(new Vector3(-20,0,0));
        
        if(Input.GetKeyDown(KeyCode.DownArrow))
            tool_Holder.Rotate(new Vector3(20f,0,0));
    }
}
