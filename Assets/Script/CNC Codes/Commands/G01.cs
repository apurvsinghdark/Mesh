﻿using UnityEngine;

[CreateAssetMenu(fileName = "New GCODES", menuName = "Commands/G01")]
public class G01 : ConsoleCommand
{
    public string msg = " ";

    string[] textSplit;

    public event System.Action<float, float, float> LinearMovement;
    
    public override bool Process(string[] args)
    {
        string logText = string.Join(" ", args);

        textSplit = logText.Split(" "[0]);

        var x = textSplit[0].Remove(0,1);
        var z = textSplit[1].Remove(0,1);
        var f = textSplit[2].Remove(0,1);

        if (!float.TryParse(x, out float xValue))
        {
            return false;
        }
        
        if (!float.TryParse(z, out float zValue))
        {
            return false;
        }
        
        if (!float.TryParse(f, out float fValue))
        {
            return false;
        }

        //Debug.Log(msg + " " + value);

        if(LinearMovement != null)
        {
            LinearMovement(xValue, zValue, fValue); 
        }

        return true;
    }
}