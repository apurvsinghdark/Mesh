using UnityEngine;

[CreateAssetMenu(fileName = "New GCODES", menuName = "Commands/G00")]
public class G00 : ConsoleCommand
{
    public string msg = " ";

    string[] textSplit;

    public event System.Action<float, float> QuickMovement;
    
    public override bool Process(string[] args)
    {
        string logText = string.Join(" ", args);

        textSplit = logText.Split(" "[0]);

        var x = textSplit[0].Remove(0,1);
        var z = textSplit[1].Remove(0,1);

        if (!float.TryParse(x, out float xValue))
        {
            return false;
        }
        
        if (!float.TryParse(z, out float zValue))
        {
            return false;
        }

        //Debug.Log(msg + " " + value);

        if(QuickMovement != null)
        {
            QuickMovement(xValue, zValue); 
        }

        return true;
    }
}

